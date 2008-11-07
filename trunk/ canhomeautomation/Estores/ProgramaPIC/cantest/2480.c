#include "C:\DomoticaNovo\Estores\ProgramaPIC\cantest\2480.h"
int x;

#define CAN_USE_EXTENDED_ID FALSE
#include <can-18xxx8.c>

#define CAN_RECEIVE_STACK_SIZE 1
int can_rspoint=0;
int can_rstack [CAN_RECEIVE_STACK_SIZE] [14];
int1 can_rsfull=FALSE;
#define can_receiver_full() can_rsfull
#define CAN_TRANSMIT_STACK_SIZE 1
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
   if(can_tspoint==-1)
      can_tspoint++;

   if(can_tspoint < CAN_TRANSMIT_STACK_SIZE)
   {
      can_tstack[can_tspoint][0]=make8(tx_id,3);
      can_tstack[can_tspoint][1]=make8(tx_id,2);
      can_tstack[can_tspoint][2]=make8(tx_id,1);
      can_tstack[can_tspoint][3]=make8(tx_id,0);

      for(i=0;i<tx_length;i++)
      {
         can_tstack[can_tspoint][i+4]=tx_buffer[i];
      }

      can_tstack[can_tspoint][12]=(tx_length<<4)|(tx_priority<<2)|((int8)tx_extendedID<<1)|((int8)tx_emptyframe);

      can_tspoint++;
   }
}
#int_canrx0
void canrx0_int ( ) {
printf("CANRX0\n\r");
   canReceive ( );
   // TODO: add CAN recieve code here
}
#int_canrx1
void canrx1_int ( ) {
printf("CANRX1\n\r");
   canReceive ( );
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
printf("CANIRX\n\r");
   // TODO: add CAN IRX handling code here
}
#int_canerr
void canerr_int ( ) {
printf("CANERR COMSTAT=%X\n\r",*0xF74);
   // TODO: add CAN error handling code here
}
void main()
{
   can_init();
   

   can_set_mode(CAN_OP_CONFIG);
   
   BRGCON1.brp=0; 
   BRGCON1.sjw=0; 
   BRGCON2.prseg=1; 
   BRGCON2.seg1ph=2; 
   BRGCON2.sam=false; 
   BRGCON2.seg2phts=true;  
   BRGCON3.seg2ph=2; 
   BRGCON3.wakfil=FALSE;
 //  ciocon.endrhi=1;
 //  ciocon.cancap=1;
   can_set_mode(CAN_OP_NORMAL);
   

   can_set_mode(CAN_OP_CONFIG);
   
   can_set_id(RX0MASK,0,CAN_USE_EXTENDED_ID);
   can_set_id(RX0FILTER0,0,CAN_USE_EXTENDED_ID);
   can_set_id(RX0FILTER1,0,CAN_USE_EXTENDED_ID);
   can_set_id(RX1MASK,0,CAN_USE_EXTENDED_ID);
   can_set_id(RX1FILTER2,0,CAN_USE_EXTENDED_ID);
   can_set_id(RX1FILTER3,0,CAN_USE_EXTENDED_ID);
   can_set_id(RX1Filter4,0,CAN_USE_EXTENDED_ID);
   can_set_id(RX1Filter5,0,CAN_USE_EXTENDED_ID);

   can_set_mode(CAN_OP_NORMAL);
   
   enable_interrupts(int_canrx0); 
   enable_interrupts(int_canrx1); 
   enable_interrupts(int_cantx0); 
   enable_interrupts(int_cantx1); 
   enable_interrupts(int_cantx2); 
   //enable_interrupts(int_canirx); 
   //enable_interrupts(int_canerr); 
   enable_interrupts(global);

   setup_adc_ports(NO_ANALOGS|VSS_VDD);
   setup_adc(ADC_OFF|ADC_TAD_MUL_0);
   setup_spi(SPI_SS_DISABLED);
   setup_wdt(WDT_OFF);
   setup_timer_0(RTCC_INTERNAL);
   setup_timer_1(T1_DISABLED);
   setup_timer_2(T2_DISABLED,0,1);
   setup_vref(FALSE);
//Setup_Oscillator parameter not selected from Intr Oscillotar Config tab

   // TODO: USER CODE!!
  // TODO: USER CODE!!
printf("START\n\r");
x=0;
while(true){
int data[4]={13,14,1};
data[3]=++x;
can_push(0,data,4,3,FALSE,FALSE);
printf("ALIVE CIOCON=%X COMSTAT=%X BRCON2=%X\n\r",*0xF73,*0xF74,*0xF71);
canTransmit ( );
delay_ms(500);
}
}
