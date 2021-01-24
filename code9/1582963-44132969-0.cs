    using System;
    using System.IO;
    using Newtonsoft.Json;
    
    public class Model
    {
        public string Foo { get; set; }
    }
    
    public class Test
    {
        static void Main()
        {
            string json = "\"{\\\"foo\\\": \\\"bar\\\"}\"";
            Console.WriteLine($"Original JSON: {json}");        
            string unwrappedJson = JsonConvert.DeserializeObject<string>(json);
            Console.WriteLine($"Unwrapped JSON: {unwrappedJson}");
            Model model = JsonConvert.DeserializeObject<Model>(unwrappedJson);
            Console.WriteLine($"model.Foo: {model.Foo}");
        }
    }
