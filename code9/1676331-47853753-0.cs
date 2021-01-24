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
                Cars cars = new Cars();
                XElement xCars = cars.Serialize();
            }
        }
        public class Cars
        {
            public Dictionary<int, ModelCar> Car { get; set; }
            public Cars()
            {
                Car = new Dictionary<int, ModelCar>() {
                    {0, new ModelCar() { _class = "B", _type = 1, id = 0}},
                    {1, new ModelCar() { _class = "B", _type = 1, id = 1}}
                };
            }
            public XElement Serialize()
            {
                return new XElement("cars", Car.AsEnumerable().Select(x => new XElement("car", new object[] {
                    new XAttribute("id", x.Key),
                    new XElement("Type", x.Value._type),
                    new XElement("Class", x.Value._class)
                })));
            }
        }
        public class ModelCar
        {
            public int id { get; set; }
            public int _type { get; set; }
            public string _class { get;set; }
        }
    }
