    namespace ConsoleApp3
    {
        using System;
        using Newtonsoft.Json.Linq;
    
        class Program
        {
            static void Main()
            {
                var text = @"{
                    'requestid': '1111',
                    'message': 'db',
                    'status': 'OK',
                    'data': [
                    {
                        'Status': 'OK', // this one I would to test first to read the other attributes
                        'fand': '',
                        'nalDate': '',
                        'price': 1230000,
                        'status': 2
                    }
                    ]
                }";
    
                var json = JObject.Parse(text);
    
                Console.WriteLine(json.SelectToken("data[0].Status").Value<string>());
                Console.ReadLine();
            }
        }
    }
