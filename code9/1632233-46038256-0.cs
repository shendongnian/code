    using System;
    using System.Diagnostics;
    using System.Threading;
    using Newtonsoft.Json;
    
    namespace ConsoleApp12
    {
    	class Program
        {
            static void Main(string[] args)
            {
    
    			
    			var str = @"{
      ""accountId"": ""496c-aed1-ab750d882fa5"",
      ""id"": ""acd8121234"",
    
    //i've cut most part of text couse of stackoverflow.com limitation on 30000 symbols. Code was tested with full json
    
      ""social"": {
        ""likedByUser"": false,
        ""likes"": 0,
        ""views"": 0
      }
    }";
    	      
    	        var sw = Stopwatch.StartNew();
    	        var obj = JsonConvert.DeserializeObject<IndexedVideoReponseVM.RootObject>(str);
    			sw.Stop();
                Console.WriteLine($"Deserialized at {sw.ElapsedMilliseconds} ms ({sw.ElapsedTicks} tiks)");
            }
        }
    }
