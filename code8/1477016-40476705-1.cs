    static void Main(string[] args)
    {
    	TemperatureConversion tempcon = new TemperatureConversion();
    	tempcon.Conversion();
    }
    
    class TemperatureConversion
    {       
        public void Conversion()
        {
            for (int celcius = 0; celcius <= 100; celcius++)
            {
                Console.Write(celcius + "C :")
    			double f = CelciusToFarenheit(celcius);
                Console.Write(" Fahrenheit: " + f);
    			
    			double c = FarenheitToCelcius(f);
    			Console.WriteLine(" Celcius: " + c);
            }
        }
    	
    	public double CelciusToFarenheit(double c)
        {
            return c * 9 / 5 + 32;
        }
        public double FarenheitToCelcius(double f)
        {
            return (f - 32) * 5 / 9;
        }
    }
