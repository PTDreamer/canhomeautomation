#include <18F2480.h>
#device adc=8
#FUSES WDT128                   //Watch Dog Timer uses 1:128 Postscale
//#fuses NOWDT
#FUSES HS                       //High speed Osc (> 4mhz)
#FUSES NOPROTECT                //Code not protected from reading
#FUSES BROWNOUT                 //Reset when brownout detected
//#FUSES BORV28                   //Brownout reset at 2.8V
#FUSES PUT                      //Power Up Timer
#FUSES NOCPD                    //No EE protection
#FUSES STVREN                   //Stack full/underflow will cause reset
#FUSES NODEBUG                  //No Debug mode for ICD
#FUSES NOLVP                    //No low voltage prgming, B3(PIC16) or B5(PIC18) used for I/O
#FUSES NOWRT                    //Program memory not write protected
#FUSES NOWRTD                   //Data EEPROM not write protected
#FUSES IESO                     //Internal External Switch Over mode enabled
#FUSES FCMEN                    //Fail-safe clock monitor enabled
#FUSES NOPBADEN                 //PORTB pins are configured as digital I/O on RESET
#FUSES BBSIZ2K                  //2K words Boot Block size
#FUSES NOWRTC                   //configuration not registers write protected
#FUSES NOWRTB                   //Boot block not write protected
#FUSES NOEBTR                   //Memory not protected from table reads
#FUSES NOEBTRB                  //Boot block not protected from table reads
#FUSES NOCPB                    //No Boot Block code protection
#FUSES LPT1OSC                  //Timer1 configured for low-power operation
#FUSES NOMCLR                     //Master Clear pin enabled
#FUSES NOXINST                    //Extended set extension and Indexed Addressing mode enabled

#use delay(clock=20000000,RESTART_WDT)
#use rs232(baud=9600,parity=N,xmit=PIN_C6,rcv=PIN_C7,bits=8,restart_wdt)



