#define Push_b 0
#define Switch_ 1

int out_value;
int switch_value;
int switch_modes;
int what_control_what[8];

int decisor(int1 curr_out_value,int1 curr_swit_value,int1 last_swit_value,int1 mode)
{    
   
   if(mode==Push_b)
   {
      if(curr_swit_value) return 1;
      else return 0;
   }
   else if (mode==Switch_)
   {
      if((curr_swit_value==1) && (last_swit_value==0)) 
      {
         if(curr_out_value) return 0;
         else 
         {
         return 1; //e pus aki
         }
         //return 1; tirei daki
      }
     else return 2;
   }
}

void output_refresh()
{
int oaux1,oaux2,out;
int old_switch,oau;
int buffer[6];
   
   old_switch=switch_value;
   switch_value=0;
   out=out_value;
   if(!input(inte0)) bit_set(switch_value,0);
   if(!input(inte1)) bit_set(switch_value,1);
   if(!input(inte2)) bit_set(switch_value,2);
   if(!input(inte3)) bit_set(switch_value,3);
   if(!input(inte4)) bit_set(switch_value,4);
   if(!input(inte5)) bit_set(switch_value,5);
   if(!input(inte6)) bit_set(switch_value,6);
   if(!input(inte7)) bit_set(switch_value,7);
   if(switch_value!=0) remote=0;
   if (remote==1) return;
   for (oaux1=0;oaux1<8;++oaux1)
   {   
         for (oaux2=0;oaux2<8;++oaux2)
         {  
            if(bit_test(what_control_what[oaux1],oaux2))
            {
               oau=decisor(bit_test(out_value,oaux2),bit_test(switch_value,oaux1) ,bit_test(old_switch,oaux1),bit_test(switch_modes,oaux1));
               if(oau==1) bit_set(out,oaux2);
               else if (oau==0) bit_clear(out,oaux2);
              
            }
         }
   }
   for(oaux1=0;oaux1<8;++oaux1)
   {  
      if(bit_test(out,oaux1)!=bit_test(out_value,oaux1))
      {
         buffer[0]=0;
         buffer[1]=ADRESS;
         buffer[2]=oaux1;
         buffer[3]=13;//man value change
         buffer[4]= bit_test(out,oaux1);
         can_push(0,buffer,5,0,false,false);
      }
   }
   out_value=out;
}
   
