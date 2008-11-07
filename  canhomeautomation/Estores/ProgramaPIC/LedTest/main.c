#include "C:\DomoticaNovo\Estores\ProgramaPIC\LedTest\main.h"


void main()
{


   setup_adc_ports(NO_ANALOGS|VSS_VDD);
   setup_adc(ADC_OFF|ADC_TAD_MUL_0);
   setup_spi(SPI_SS_DISABLED);
   setup_wdt(WDT_OFF);
   setup_timer_0(RTCC_INTERNAL);
   setup_timer_1(T1_DISABLED);
   setup_timer_2(T2_DISABLED,0,1);
   setup_vref(FALSE);
   printf("olaaaaaa.....");
   while(true)
   {
     printf("adeus.....");
   output_high(pin_c0);
   delay_ms(100);
   output_low(pin_c0);
   delay_ms(100);
   }
//Setup_Oscillator parameter not selected from Intr Oscillotar Config tab

   // TODO: USER CODE!!

}
