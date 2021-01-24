    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace TestsJson
    {
        class Model
        {
            public DateTime Date { get; set; }
    
            public int Clicks { get; set; }
    
            public Model(DateTime date, int clicks)
            {
                Date = date;
                Clicks = clicks;
            }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                var data = new List<Model>()
                {
                    new Model(new DateTime(2017, 01, 21), 14),
                    new Model(new DateTime(2017, 01, 22), 17),
                    new Model(new DateTime(2017, 01, 23), 50),
                    new Model(new DateTime(2017, 01, 24), 0),
                    new Model(new DateTime(2017, 01, 25), 2),
                    new Model(new DateTime(2017, 01, 26), 0)
                };
    
                foreach (var model in data)
                {
                    var json = "{" + JsonConvert.SerializeObject(model.Date.ToShortDateString()) + ":" + model.Clicks + "}";
                    Console.WriteLine(json);
                }
                    
                Console.Read();
            }
        }
    }
