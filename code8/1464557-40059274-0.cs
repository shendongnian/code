    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.IO;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.txt";
            static void Main(string[] args)
            {
                StreamReader reader = new StreamReader(FILENAME);
                string inputLine = "";
                Person newPerson = null;
                while((inputLine = reader.ReadLine()) != null);
                {
                    inputLine = inputLine.Trim();
                    if (inputLine.Length > 0)
                    {
                        if (inputLine.Contains("Information"))
                        {
                            newPerson = new Person();
                            Person.peopel.Add(newPerson);
                        }
                        else
                        {
                            //enter code to parse data
                        }
                    }
                }
            }
        }
        public class Person
        {
            public static List<Person> peopel = new List<Person>();
            public Dictionary<string, string> properties = new Dictionary<string, string>();
        }
    }
