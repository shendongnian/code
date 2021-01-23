    using System;
    using System.Collections.Generic;
    using System.Dynamic;
    namespace myApp
    {
        public class myClass
        {
            public string myProp { get; set; }
            public string myField;
            public string myFunction()
            {
                return "";
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                var fields = typeof(myClass).GetFields();
                dynamic EO = new ExpandoObject();
                for (int i = 0; i < fields.Length; i++)
                {
                    AddProperty(EO, "Language", "English");
                    Console.Write(EO.Language);
                }
            }
            public static void AddProperty(ExpandoObject expando, string propertyName, object propertyValue)
            {
                // ExpandoObject supports IDictionary so we can extend it like this
                var expandoDict = expando as IDictionary<string, object>;
                if (expandoDict.ContainsKey(propertyName))
                    expandoDict[propertyName] = propertyValue;
                else
                    expandoDict.Add(propertyName, propertyValue);
            }
        }
    } 
