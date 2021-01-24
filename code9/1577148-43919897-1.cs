    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    namespace ConsoleApplication55
    {
        class Program
        {
            static void Main(string[] args)
            {
                string[] inputs = {
                    "Humidity: 33 %",
                    "Temperature: 25.7 deg C",
                    "Visible light: 112 lx",
                    "Infrared radiation: 1802.5 mW/m2",
                    "UV index: 0.12",
                    "CO2: 404 ppm CO2",
                    "Pressure: 102126 Pa"
                                 };
                string pattern = @"^(?'name'[^:]+):\s(?'value'[\d.]+)";
                Dictionary<string, decimal> dict = new Dictionary<string,decimal>();
                foreach(string input in inputs)
                {
                    Match match = Regex.Match(input,pattern);
                    string name = match.Groups["name"].Value;
                    decimal value = decimal.Parse(match.Groups["value"].Value);
                    Console.WriteLine("name = '{0}', value = '{1}'", name, value);
                    dict.Add(name, value);
                }
                Console.ReadLine();
            }
        }
       
    }
