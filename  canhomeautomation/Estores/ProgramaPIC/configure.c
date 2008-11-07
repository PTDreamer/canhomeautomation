

void configure()
{
while (true)
{
   char string[30];
   char cc;
   int ci,ci2;
   printf("\n\r");
   printf("*****************************\n\r");
   printf("* A-Configure Module Adress *\n\r");
   printf("* C-Configure Can           *\n\r");
   printf("* Q-Quit and Reset          *\n\r");
   printf("* W-Write EEPROM            *\n\r");
   printf("* R-Read EEPROM             *\n\r");
   printf("*****************************\n\r");
   
   while(!kbhit()){}
   cc=getc();
   if (cc=='a')
   {
   printf("**********************\n\r");
   printf("* Current adress=%u  *\n\r",read_eeprom(EADRESS));
   printf("**********************\n\r\n\r");
   printf("New Adress:");
   gets(string);
   ci=atoi(string);
   printf("\n\r Gravar? Y/N \n\r");
   gets(string);
   if (string=="y") write_eeprom(EADRESS,ci);
   }
   else if (cc=='r') 
   {
      printf("Endereco a ler?:");
      gets(string);
      printf("Endereco 0x%X=0x%X\n\r",atoi(string),read_eeprom(atoi(string)));
   }
   else if (cc=='w')
   {
      printf("Endereco a escrever?:");
      gets(string);
      ci=atoi(string);
      printf("Endereco a escrever?:");
      ci2=atoi(string);
      printf("\n\r Gravar? Y/N \n\r");
      gets(string);
      if (string=="y") write_eeprom(ci,ci2);
   }
      
   else if (cc=='q') reset_cpu();
   else if (cc=='c')
   {
   printf("************************\n\r");
   printf("* Current BRP=%u       *\n\r",read_eeprom(EADRESS));
   printf("* Current SJW=%u       *\n\r",read_eeprom(ESJW));
   printf("* Current PHSEG1=%u    *\n\r",read_eeprom(EPHSEG1));
   printf("* Current SEG2PHTS=%u  *\n\r",read_eeprom(ESEG2PHTS));
   printf("* Current PHSEG2=%u    *\n\r",read_eeprom(EPHSEG2));
   printf("* Current PRSEG=%u     *\n\r",read_eeprom(EPRSEG)); 
   printf("************************\n\r\n\r");
   printf("New BRP:");
   gets(string);
   ci=atoi(string);
   printf("\n\r Gravar novo BRP Y/N \n\r");
   gets(string);
   if (string=="y") write_eeprom(EBRP,ci);
   printf("New PHSEG1:");
   gets(string);
   ci=atoi(string);
   printf("\n\r Gravar novo PHSEG1 Y/N \n\r");
   gets(string);
   if (string=="y") write_eeprom(EPHSEG1,ci);
   printf("New PHSEG2:");
   gets(string);
   ci=atoi(string);
   printf("\n\r Gravar novo PHSEG2 Y/N \n\r");
   gets(string);
   if (string=="y") write_eeprom(EPHSEG2,ci);
   printf("New PRSEG:");
   gets(string);
   ci=atoi(string);
   printf("\n\r Gravar novo PRSEG Y/N \n\r");
   gets(string);
   if (string=="y") write_eeprom(EPRSEG,ci);
   printf("New SJW:");
   gets(string);
   ci=atoi(string);
   printf("\n\r Gravar novo SJW Y/N \n\r");
   gets(string);
   if (string=="y") write_eeprom(ESJW,ci);
   printf("New SEG2PHTS:");
   gets(string);
   ci=atoi(string);
   printf("\n\r Gravar novo SEG2PHTS Y/N \n\r");
   gets(string);
   if (string=="y") write_eeprom(ESEG2PHTS,ci);
   }
}
}
