
#define inte0 pin_a0
#define inte1 pin_a1
#define inte2 pin_a2
#define inte3 pin_a3
#define inte4 pin_a4
#define inte5 pin_a5
#define inte6 pin_b1
#define inte7 pin_b0


#include "C:\DomoticaNovo\Estores\ProgramaPIC\estores.h"
#include <stdlib.h>
#include "C:\DomoticaNovo\Estores\ProgramaPIC\max4896.c"
#include "C:\DomoticaNovo\Estores\ProgramaPIC\console.c"
int x;
int1 remote;
void canTransmit ( );
int ADRESS;
int1 can_push (int32 tx_id, int8 * tx_buffer, int8 tx_length, int8 tx_priority, int1 tx_extendedID, int1 tx_emptyframe);
#include "C:\DomoticaNovo\Estores\ProgramaPIC\switch_decision.c"

#define EADRESS 4
#define DEV_ID 0

#include "C:\DomoticaNovo\Estores\ProgramaPIC\can_proc.c"

//EEPROM Adress definitions
 #define EBRP 7
 #define ESEG2PHTS 5
 #define ESJW 6
 #define EPHSEG1 1
 #define EPHSEG2 2
 #define EPRSEG 3

 //DEBUG MODES
 
 #define NODEBUG 0
 #define D_RS232 1
 #define DCAN 2
#include "C:\DomoticaNovo\Estores\ProgramaPIC\configure.c"

int DEBUG_MODE;
char ch;

#int_RDA
void  RDA_isr(void) 
{
  ch=getc();
  console(ch);
   
}

#int_LOWVOLT
void  LOWVOLT_isr(void) 
{
   printf("ERROR LOW VOLTAGE DETECTED\n\r");
}



#int_OSCF
void  OSCF_isr(void) 
{

}

 

#define CAN_USE_EXTENDED_ID FALSE
#include <can-18xxx8.c>

#define CAN_RECEIVE_STACK_SIZE 1
int can_rspoint=-1;
int can_rstack [CAN_RECEIVE_STACK_SIZE] [14];
int1 can_rsfull=FALSE;
#define can_receiver_full() can_rsfull
#define CAN_TRANSMIT_STACK_SIZE 8
int can_tspoint=-1;
int can_tstack [CAN_TRANSMIT_STACK_SIZE] [13];
int1 can_tsempty=TRUE;
#define can_transmitter_empty() can_tsempty

void canReceive ( )
{
   int32 rx_id;
   int8  rx_len, rx_stat;
   int8  buffer [8];
   int8  i;

   if(can_rspoint==-1)
      can_rspoint++;

   if(can_rspoint < CAN_RECEIVE_STACK_SIZE)
   {
      
      can_getd(rx_id,buffer,rx_len,rx_stat);
      can_rstack[can_rspoint][0]=make8(rx_id,3);
      can_rstack[can_rspoint][1]=make8(rx_id,2);
      can_rstack[can_rspoint][2]=make8(rx_id,1);
      can_rstack[can_rspoint][3]=make8(rx_id,0);

      can_rstack[can_rspoint][4]=rx_len;
      can_rstack[can_rspoint][5]=rx_stat;

      for(i=0;i<rx_len;i++)
      {
         can_rstack[can_rspoint][i+6]=buffer[i];
      }

      can_rspoint++;
   }
   else
      can_getd(rx_id,buffer,rx_len,rx_stat);
}


int1 can_Pop ( int32 & rx_id, int * buffer, int & rx_len, int & rx_stat )
{
   int i;

   if(can_rspoint==CAN_RECEIVE_STACK_SIZE)
      can_rspoint--;

   if(can_rspoint!=-1)
   {
      rx_id=make32(can_rstack[can_rspoint][0],
                  can_rstack[can_rspoint][1],
                  can_rstack[can_rspoint][2],
                  can_rstack[can_rspoint][3]);

      rx_len=can_rstack[can_rspoint][4];
      rx_stat=can_rstack[can_rspoint][5];

      for(i=0;i<rx_len;i++)
      {
         buffer[i]=can_rstack[can_rspoint][i+6];
      }
      can_rspoint--;

      return TRUE;
   }   
   else
   return FALSE;
}


void canTransmit ( )
{
   int32 tx_id;
   int8  tx_length;
   int8  tx_priority;
   int8  tx_buffer[8];
   int1  tx_extendedID;
   int1  tx_emptyframe;
   int8  i;
   
   if(can_tspoint==CAN_TRANSMIT_STACK_SIZE)
   {
      can_tspoint--;
   }
   if(can_tspoint!=-1)
   {
      delay_ms(10);
      tx_id=make32(can_tstack[can_tspoint][0],
                  can_tstack[can_tspoint][1],
                  can_tstack[can_tspoint][2],
                  can_tstack[can_tspoint][3]);

      tx_length=can_tstack[can_tspoint][12]>>4;
      tx_priority=(can_tstack[can_tspoint][12]&0x0c)>>2;
      tx_extendedID=bit_test(can_tstack[can_tspoint][12],1);
      tx_emptyframe=bit_test(can_tstack[can_tspoint][12],0);

      for(i=0;i<tx_length;i++)
      {
         tx_buffer[i]=can_tstack[can_tspoint][i+4];
      }

      can_putd(tx_id,tx_buffer,tx_length,tx_priority,tx_extendedID,tx_emptyframe);

      can_tspoint--;
   }
   else
      return;
}


int1 can_push (int32 tx_id, int8 * tx_buffer, int8 tx_length, int8 tx_priority, int1 tx_extendedID, int1 tx_emptyframe)
{
   int8  i;
   
  /* if(can_tspoint==-1)
      can_tspoint++;*/

   if(can_tspoint+1 < CAN_TRANSMIT_STACK_SIZE)
   {
     
      can_tstack[can_tspoint+1][0]=make8(tx_id,3);
      can_tstack[can_tspoint+1][1]=make8(tx_id,2);
      can_tstack[can_tspoint+1][2]=make8(tx_id,1);
      can_tstack[can_tspoint+1][3]=make8(tx_id,0);

      for(i=0;i<tx_length;i++)
      {
         can_tstack[can_tspoint+1][i+4]=tx_buffer[i];
      }

      can_tstack[can_tspoint+1][12]=(tx_length<<4)|(tx_priority<<2)|((int8)tx_extendedID<<1)|((int8)tx_emptyframe);

       can_tspoint++;
   }
}


#int_canrx0
void canrx0_int ( ) {
   if(DEBUG_MODE==D_RS232) 
   {
   printf("Can Message Received processing on canrx0_int\n\r");
   canReceive ( );
   printCAN();
   }
   else canReceive ( );
   // TODO: add CAN recieve code here
}
#int_canrx1
void canrx1_int ( ) {
    if(DEBUG_MODE==D_RS232) 
   {
   printf("Can Message Received processing on canrx1_int\n\r");
   canReceive ( );
   printCAN();
   }
   else canReceive ( );
   // TODO: add CAN recieve code here
}
#int_cantx0
void cantx0_int ( ) {
   canTransmit ( );
   // TODO: add CAN transmit code here
}
#int_cantx1
void cantx1_int ( ) {
   canTransmit ( );
   // TODO: add CAN transmit code here
}
#int_cantx2
void cantx2_int ( ) {
   canTransmit ( );
   // TODO: add CAN transmit code here
}
#int_canirx
void canirx_int ( ) {
 if(DEBUG_MODE==D_RS232) 
   {
   printf("Can IRX Received processing on canirx_int\n\r");
   
   }
   // TODO: add CAN IRX handling code here
}
#int_canerr
void canerr_int ( ) {
  if(DEBUG_MODE==D_RS232) 
   {
      printf("Can ERROR Received processing on canerr_int\n\r");
   }
 // TODO: add CAN error handling code here
}
void main()
{
   long timeout;
   
   int BRP,PRSEG,PHSEG1,PHSEG2,SJW,SEG2PHTS;
   char mc;
   int rbuffer[6],stat,lenght,aux;
   int32 send_id;
   int16 au16;
   
  
   printf("Last Reset Cause:%X\r\n",restart_cause());
   printf("\n\r Module Starting PRESS D TO DEBUG, C TO CONFIGURE...\n\r");
   
   DEBUG_MODE=NODEBUG;
   remote=0;
   timeout=0;
   while(!kbhit()&&(++timeout<20000)) delay_us(100);
   if(kbhit())
   {
          mc=getc();
          if(mc=='d') DEBUG_MODE=D_RS232;
          else if(mc=='c') configure();
          
          printf("\n\r Starting in Debug Mode PRESS C FOR CONSOLE\n\r");
          enable_interrupts(INT_RDA);
   }
   else 
   {
          printf("\n\r Starting in Normal Mode \n\r");
   }




   
   can_init();
   

   can_set_mode(CAN_OP_CONFIG);
   
   write_EEPROM(DEV_ID,10);//novos codigos para identificar o device
   BRP=read_EEPROM(EBRP);
   PRSEG=read_EEPROM(EPRSEG);
   PHSEG1=read_EEPROM(EPHSEG1);
   PHSEG2=read_EEPROM(EPHSEG2);
   ADRESS=read_EEPROM(EADRESS);
   SJW=read_EEPROM(ESJW);
   SEG2PHTS=read_EEPROM(ESEG2PHTS);
   
   if(BRP==0xFF)
   {
   printf("Loading CAN defaults\n\r");
   BRP=0;
   SJW=0;
   PRSEG=1;
   PHSEG1=2;
   SEG2PHTS=true;
   PHSEG2=2;
   }
   if(ADRESS==0xFF)
   {
   printf("Adress not Set Loading default ADR 30\n\r");
   ADRESS=0x30;
   }
  
   switch_modes=read_eeprom(20);
   for(x=0;x<8;++x)
   {
      what_control_what[x]=read_EEPROM(10+x);
   }
   BRGCON1.brp=BRP; 
   BRGCON1.sjw=SJW; 
   BRGCON2.prseg=PRSEG; 
   BRGCON2.seg1ph=PHSEG1; 
   BRGCON2.sam=FALSE; 
   BRGCON2.seg2phts=SEG2PHTS;  
   BRGCON3.seg2ph=PHSEG2; 
   BRGCON3.wakfil=FALSE; 

   can_set_mode(CAN_OP_NORMAL);

   can_set_mode(CAN_OP_CONFIG);
   can_set_id(RX0MASK,0xFFFF,CAN_USE_EXTENDED_ID);
   can_set_id(RX0FILTER0,MAKE16((ADRESS >>5) & 0x07,(ADRESS << 3) & 0xF8),CAN_USE_EXTENDED_ID);
   can_set_id(RX0FILTER1,0x69F0,CAN_USE_EXTENDED_ID);
   can_set_id(RX1MASK,0xFFFF,CAN_USE_EXTENDED_ID);
   can_set_id(RX1FILTER2,MAKE16(ADRESS,0x00),CAN_USE_EXTENDED_ID);
   can_set_id(RX1FILTER3,0x69F0,CAN_USE_EXTENDED_ID);
   can_set_id(RX1Filter4,0xFFF0,CAN_USE_EXTENDED_ID);
   can_set_id(RX1Filter5,0xFFF0,CAN_USE_EXTENDED_ID);

   can_set_mode(CAN_OP_NORMAL);
  
   enable_interrupts(int_canrx0); 
   enable_interrupts(int_canrx1); 
   enable_interrupts(int_cantx0); 
   enable_interrupts(int_cantx1); 
   enable_interrupts(int_cantx2); 
   enable_interrupts(int_canirx); 
   enable_interrupts(int_canerr); 


   setup_adc_ports(NO_ANALOGS|VSS_VDD);
   setup_adc(ADC_OFF|ADC_TAD_MUL_0);
   setup_spi(SPI_MASTER|SPI_L_TO_H|SPI_XMIT_L_TO_H|SPI_CLK_DIV_4);
   write4896(0);
   if (DEBUG_MODE==NODEBUG)  setup_wdt(WDT_ON);
   else setup_wdt(WDT_OFF);
   setup_timer_0(RTCC_INTERNAL);
   setup_timer_1(T1_DISABLED);
   setup_timer_2(T2_DISABLED,0,1);
   setup_timer_3(T3_DISABLED|T3_DIV_BY_1);
   setup_vref(FALSE);
   
   enable_interrupts(INT_LOWVOLT);
   enable_interrupts(INT_CANIRX);
   enable_interrupts(INT_CANERR);
   enable_interrupts(INT_CANRX1);
   enable_interrupts(INT_CANRX0);
   enable_interrupts(INT_OSCF);
   enable_interrupts(GLOBAL);
  
//Setup_Oscillator parameter not selected from Intr Oscillotar Config tab
   out_value=0;
   // TODO: USER CODE!!
   while(true){
   restart_wdt();
   if(can_Pop(send_id,rbuffer,lenght,stat)) proc_can(send_id,rbuffer,lenght);
   output_refresh();
  /* if(DEBUG_MODE==D_RS232) 
   {
      delay_ms(500);
      printf("OUTPUT:%X\n\r",out_value);
   }*/
   write4896(out_value);
   canTransmit ( );
   }


}
