        class Program
        {
            const int NUMBER_PORTS = 5;
            static void Main(string[] args)
            {
                for(int i = 0; i < NUMBER_PORTS; i++)
                {
                    WeatherLoopData newStation = new WeatherLoopData("Com" + (i + 1).ToString());
                    WeatherLoopData.ports.Add(newStation);
                }
                
            }
            public class WeatherLoopData
            {
                public static List<WeatherLoopData> ports = new List<WeatherLoopData>();
                SerialPort port = null;
                public WeatherLoopData(string portName)
                {
                    port = new SerialPort(portName);
                }
                //enter your code here
            }
