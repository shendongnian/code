    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Reflection;
    using System.Threading;
    using Newtonsoft.Json;
    
    namespace test
    {
        class Program
        {
            static void Main(string[] args)
            {
                //Your culture
                Console.WriteLine("Your Culture:" + Thread.CurrentThread.CurrentCulture.Name);
                //your JsonConvert Assembly version
                Console.WriteLine("JsonConvert Assembly" + JsonConvertVersion());
                //I guess you have welsh culture, by your nickname
                //Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("cy-GB");
                var stringified = "{\"STARTTIME\":\"12:00\",\"ENGINNEERSIGNATURE\":\"Engineer Signature .jpg\",\"OVERNIGHTS\":\"1\",\"SIGNOUT\":\"Yes\"}";
                Console.WriteLine(stringified);
                //Invariant culture witch shoudn't fail
                var settings = new JsonSerializerSettings() { Culture = System.Globalization.CultureInfo.InvariantCulture };
                var dataOut = JsonConvert.DeserializeObject<Dictionary<string, string>>(stringified, settings);
                //welsh culture, case I think that is what you are using, but for me is working 
                var settings2 = new JsonSerializerSettings() { Culture = new System.Globalization.CultureInfo("cy-GB", false) };//Welsh 
                var dataOut2 = JsonConvert.DeserializeObject<Dictionary<string, string>>(stringified, settings2);
                //object with invariant culture
                Console.WriteLine(dataOut);
                //object with welsh culture
                Console.WriteLine(dataOut2);
                Console.WriteLine(JsonConvert.SerializeObject(dataOut));
                Console.WriteLine(JsonConvert.SerializeObject(dataOut2));
                
            }
            public static string JsonConvertVersion()
            {
                Assembly asm = Assembly.GetAssembly(typeof(JsonConvert));
                FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(asm.Location);
                return String.Format("{0}.{1}", fvi.FileMajorPart, fvi.FileMinorPart);
                
            }
        }
    }
