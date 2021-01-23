    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    
    namespace Rextester
    {
        public class Program
        {
            public static void Main(string[] args)
            {
                var itemDetails = new List<Guitar>(){
                    new Guitar("Electric", "KA123"),
                    new Guitar("Manual", "model2"),
                    new Guitar("Get this one", "main model")
                };
                
                // only this one line code needed to get specific item by index
                var gList = itemDetails[2];                
                Console.WriteLine("Type:{0}, Model:{1}", gList.Type, gList.Model);
            }
            
            public class Guitar 
            {
                public Guitar(string type, string model) {
                    Type = type;
                    Model = model;
                }
                public string Type {get;set;}
                public string Model {get;set;}
            }
        }
    }
