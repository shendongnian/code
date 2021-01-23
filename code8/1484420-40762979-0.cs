    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Dynamic;
    using System.Reflection;
    using Newtonsoft;
    
    
    namespace JsonToCsvTests
    {
        using Newtonsoft.Json;
        using System.IO;
        using System.Threading.Tasks;
    
        class Program
        {
    
            static void Main(string[] args)
            {
                TestJsonToCsv();
                Console.ReadLine();
            }
    
            static void TestJsonToCsv()
            {
                string jsonData = @"jsonData = [
                            {
                                ""DocumentName"": ""Test Document"",
                                ""ActionDate"": ""2015-09-25T16:06:25.083"",
                                ""ActionType"": ""View"",
                                ""ActionPerformedBy"": ""Sreeja SJ""
                            },
                            {
                                ""DocumentName"": ""Test Document"",
                                ""ActionDate"": ""2015-09-25T16:12:02.497"",
                                ""ActionType"": ""View"",
                                ""ActionPerformedBy"": ""Sreeja SJ""
                            },
                            {
                                ""DocumentName"": ""Test Document"",
                                ""ActionDate"": ""2015-09-25T16:13:48.013"",
                                ""ActionType"": ""View"",
                                ""ActionPerformedBy"": ""Sreeja SJ""
                            }]";
    
                Console.WriteLine("...using System.Dynamic and casts");
                Console.WriteLine();
                Console.WriteLine(JsonToCsv(jsonData, ","));
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("...using a provided StrongType with System.Reflection.");
                Console.WriteLine();
                Console.WriteLine(JsonToCsv<JsonData>(jsonData, ","));
            }
    
            static private string JsonToCsv(string jsonContent, string delimiter)
            {
                var data = jsonStringToTable(jsonContent);
                var headers = ((IEnumerable<dynamic>)((IEnumerable<dynamic>)data).First()).Select((prop) => prop.Name).ToArray();
                var csvList = new List<string> 
                {
                    string.Join(delimiter, headers.Select((prop) => string.Format(@"""{0}""", prop)).ToArray())
                };
    
                var lines = ((IEnumerable<dynamic>)data)
                    .Select(row => row)
                    .Cast<IEnumerable<dynamic>>()
                    .Select((instance) => string.Join(delimiter, instance.Select((v) => string.Format(@"""{0}""", v.Value))))
                    .ToArray();
    
                csvList.AddRange(lines);
                return string.Join(Environment.NewLine, csvList );
            }
    
            static private string JsonToCsv<T>(string jsonContent, string delimiter) where T : class
            {
                var data = jsonStringToTable<T>(jsonContent);
    
                var properties = data.First().GetType().GetProperties();
                
                var lines = string.Join(Environment.NewLine,
                    string.Join(delimiter, properties.Select((propInfo) => string.Format(@"""{0}""", propInfo.Name))),
                    string.Join(Environment.NewLine, data.Select((row) => string.Join(delimiter, properties.Select((propInfo) => string.Format(@"""{0}""", propInfo.GetValue(row)))))));
    
                return lines;
            }
    
            static private dynamic jsonStringToTable(string jsonContent)
            {
                var json = jsonContent.Split(new[] { '=' }).Last();
                return JsonConvert.DeserializeObject<dynamic>(json);
            }
    
            static private IEnumerable<T> jsonStringToTable<T>(string jsonContent) where T : class
            {
                var json = jsonContent.Split(new[] { '=' }).Last();
                return JsonConvert.DeserializeObject<IEnumerable<T>>(json);
            }
    
            public class JsonData
            {
                public string DocumentName { get; set; }
                public DateTime ActionDate { get; set; }
                public string ActionType { get; set; }
                public string ActionPerformedBy { get; set; }
            }
        }
    }
