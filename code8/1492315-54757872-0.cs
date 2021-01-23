     using Microsoft.AspNetCore.Mvc;
     
     class SomeClass 
     {
         public string value1 {get; set;}
         public int value2 {get; set;}
     }
    
     // Controller code
     List<SomeClass> result = // Init list using Linq Select or similar
     return new JsonResult(result);
