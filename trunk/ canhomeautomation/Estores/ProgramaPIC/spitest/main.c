#include "C:\DomoticaNovo\Estores\ProgramaPIC\spitest\main.h"
#include <stdlib.h>



void main()
{
   int i;
   char c;
   setup_adc_ports(NO_ANALOGS|VSS_VDD);
   setup_adc(ADC_OFF|ADC_TAD_MUL_0);
   setup_spi(SPI_MASTER|SPI_L_TO_H|SPI_XMIT_L_TO_H|SPI_CLK_DIV_4);
   setup_wdt(WDT_OFF);
   setup_timer_0(RTCC_INTERNAL);
   setup_timer_1(T1_DISABLED);
   setup_timer_2(T2_DISABLED,0,1);
   setup_vref(FALSE);
//Setup_Oscillator parameter not selected from Intr Oscillotar Config tab

   // TODO: USER CODE!!
   printf("inicio...\r\n");
   while(true)
   {
   c=getc();
   i=atoi(&c);
   output_low(pin_c2);
   spi_write(i);
   output_high(pin_c2);
   printf("escrito:%u \r\n",i);
}
}
