#include "C:\DomoticaNovo\Estores\ProgramaPIC\lixo\bootloader.h"
#include "C:\DomoticaNovo\Estores\ProgramaPIC\lixo\bootloader_bootloader.h"


//BOOTLOADER AT START - Include Bootloader.h in your application - See sample application Ex_Bootload.c  
//BOOTLOADER AT END - Always include the projectname_bootloader.h file in future versions of the project
void main()
{// Enter Bootloader if Pin B5 is low after a RESET
   if(!input(PIN_B5))
   {
      load_program();
   }

      printf("Application...");


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

}
