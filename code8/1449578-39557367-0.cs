     using System.Reflection;
     foreach(PropertyInfo p in typeof(UnityEngine.GameObject).GHetProperties()){
         Console.WriteLine(p.Name+","+p.GetType().ToString());
     }
     //repeat as necessary with fields and methods and ... as needed using System.Reflection
