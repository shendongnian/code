    using System;
    using System.Collections.Generic;
    using System.IO;
    using Newtonsoft.Json;
    
    namespace StackOverflow
    {
        class Program
        {
            public static void Main()
            {
                var exampleData = new ExampleClass
                {
                    Property1 = "Bob",
                    Property2 = 2,
                    Property3 = DateTime.Today,
                    Property4 = new List<SubExampleClass>
                    {
                        new SubExampleClass
                        {
                            Property5 = "Something"
                        },
                        new SubExampleClass
                        {
                            Property5 = "Something Else"
                        }
                    }
                };
                var jsonData = JsonConvert.SerializeObject(exampleData);
    
                const string testFile = @"c:\temp\example.json";
    
                File.WriteAllText(testFile,jsonData);
            }
        }
    
        public class ExampleClass
        {
            public string Property1 { get; set; }
            public int Property2 { get; set; }
            public DateTime Property3 { get; set; }
            public List<SubExampleClass> Property4 { get; set; }
        }
    
        public class SubExampleClass
        {
            public string Property5 { get; set; }
        }
    }
