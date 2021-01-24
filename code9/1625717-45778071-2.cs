    using System;
    using System.Collections.Generic;
    using System.Linq;
    class Program
    {
        static void Main(string[] args)
        {
            List<teamNeeds> list = new List<teamNeeds> {
                new teamNeeds("abc", "starter", "ka", "starter")
            };
            //iterate over list and reflect properties
            foreach (var item in list) {
                foreach (var prop in item.GetType().GetProperties())
                {
                    if(prop != null && prop.GetValue(item, null).ToString() == "starter")
                        Console.WriteLine("{0} = {1}", prop.Name, prop.GetValue(item, null));
                }
            }
            //same via linq      
            var selectedViaLinq = list.Select(item =>
            {
                return item.GetType().GetProperties().Where(prop => prop.GetValue(item, null) == "starter").ToList();
            }).ToList();
        }
    }
    public class teamNeeds
    {
        public teamNeeds(string qb, string rb, string wr, string te)
        {
            QB = qb;
            RB = rb;
            WR = wr;
            TE = te;
        }
        public string QB { get; set; }
        public string RB { get; set; }
        public string WR { get; set; }
        public string TE { get; set; }
    }
