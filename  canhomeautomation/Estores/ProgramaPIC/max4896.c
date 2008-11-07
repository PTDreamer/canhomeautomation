#define CS pin_c2
#define delayMAX 300

int relevalue=0;

void write4896(value)
{
relevalue=value;
output_low(CS);
spi_write(value);
output_high(CS);

}



