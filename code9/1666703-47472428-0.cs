    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                XElement select = new XElement("select");
                foreach (Car car in Car.cars)
                {
                    XElement newCar = new XElement("optgroup", new XAttribute("label", car.country));
                    select.Add(newCar);
                    foreach (string name in car.names)
                    {
                        newCar.Add(new XElement("option", new object[] {
                           new XAttribute("value", name),
                           name
                        }));
                    }
                }
            }
        }
        public class Car
        {
            public static List<Car> cars = new List<Car>() {
                new Car() {
                    country = "Swedish Cars",
                    names = new List<string> {"Volvo", "saab"}
                },
                new Car() {
                    country = "German Cars",
                    names = new List<string> {"mercedes", "audi"}
                }
            };
            public string country { get; set; }
            public List<string> names { get; set; }
        }
    }
