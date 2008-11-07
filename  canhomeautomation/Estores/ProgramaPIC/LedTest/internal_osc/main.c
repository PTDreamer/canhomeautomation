#include "C:\DomoticaNovo\Estores\ProgramaPIC\LedTest\internal_osc\main.h"


void main()
{

   setup_adc_ports(NO_ANALOGS|VSS_VDD);
   setup_adc(ADC_OFF|ADC_TAD_MUL_0);
   setup_spi(SPI_SS_DISABLED);
   setup_wdt(WDT_OFF);
   setup_timer_0(RTCC_INTERNAL);
   setup_timer_1(T1_DISABLED);
   setup_timer_2(T2_DISABLED,0,1);
   setup_timer_3(T3_DISABLED|T3_DIV_BY_1);
   setup_vref(FALSE);
//Setup_Oscillator parameter not selected from Intr Oscillotar Config tab
printf("ommnmninini...........");
 while(true)
   {
   output_high(pin_c0);
   delay_ms(1000);
   output_low(pin_c0);
   delay_ms(1000);
   }
   // TODO: USER CODE!!

}
