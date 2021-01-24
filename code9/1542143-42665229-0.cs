    public class Program
    {
    public static void Main(string[] args)
    {
    Random rnd = new Random();
    int temperature = rnd.Next(0,50);
    int windSpeed = rnd.Next(4,30);
    Console.Write("Temperature: {0}", temperature);
    Console.WriteLine();
    Console.Write("Wind Speed: {0}", windSpeed);
    Console.WriteLine();
    // Not sure what you are trying to do here?
    Console.Write("Temperature (including windchill): {0}",ComputeWindChill.windChill);
   
    double windChill=0;
   
    ComputeWindChill(temperature,windSpeed,windChill);
   
    ComputeWindChill(windSpeed);
    } // end Main
    public static double ComputeWindChill(int temperature,int windSpeed,out double windChill)
    {
          windChill = 35.74 + 0.6215 * temperature - 35.75 * Math.Pow(windSpeed,0.16) +
                 0.4275 * temperature * Math.Pow(windSpeed,0.16);
    return windChill; 
    }
    }
