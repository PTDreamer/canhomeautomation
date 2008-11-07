#include "C:\DomoticaNovo\Estores\ProgramaPIC\cantest\main.h"


#define CAN_USE_EXTENDED_ID FALSE

#include <can-mcp2510.c>

void main()
{
	can_init();
	
	can_set_mode(CAN_OP_CONFIG);

	struct struct_CNF1 new_CNF1;
	struct struct_CNF2 new_CNF2;
	struct struct_CNF3 new_CNF3;

	new_CNF1.brp=0;
	new_CNF1.sjw=0;

	new_CNF2.prseg=1;
	new_CNF2.phseg1=2;
	new_CNF2.sam=FALSE;
	new_CNF2.btlmode=FALSE;

	new_CNF3.phseg2=3;
	new_CNF3.wakfil=FALSE;

	mcp2510_write(CNF1, (int)new_CNF1);
	mcp2510_write(CNF2, (int)new_CNF2);
	mcp2510_write(CNF3, (int)new_CNF3);
	
	can_set_mode(CAN_OP_NORMAL);
	


   setup_adc_ports(NO_ANALOGS);
   setup_adc(ADC_OFF);
   setup_spi(SPI_SS_DISABLED);
   setup_timer_0(RTCC_INTERNAL|RTCC_DIV_1););
   setup_timer_1(T1_DISABLED);
   setup_timer_2(T2_DISABLED,0,1);
   setup_comparator(NC_NC_NC_NC);
   setup_vref(FALSE);

   // TODO: USER CODE!!

}
