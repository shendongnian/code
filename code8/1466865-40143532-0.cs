    using System;
    using Newtonsoft.Json;		
    
    
    public class Program
    {
    	public class MyClass{ public string Property {get;set;}}
    	
    	public static void Main()
    	{
    		
    		int Num = 3;
    		string Str = "test";
    		MyClass Obj = new MyClass() { Property = "Hellow World"};
    		
    		object[] data = new object[] {Num, Str, Obj};
    		
    		string json = JsonConvert.SerializeObject(data);
    		
     		Console.WriteLine("Serialized Object: ");		
    		Console.WriteLine(json);
    		
    		dynamic deserializedData = JsonConvert.DeserializeObject(json);
    		
    		int Num2 = deserializedData[0];
    		string Str2 = deserializedData[1];
    		MyClass Obj2 = deserializedData[2].ToObject<MyClass>();
    	
    		Console.WriteLine();
    		Console.WriteLine("Deserialized Values: ");		
    		Console.WriteLine("Num: {0} - {1} Equal: {2}",Num,Num2,Num==Num2);
    		Console.WriteLine("Str: {0} - {1} Equal: {2}",Str,Str2,Str==Str2);
    		Console.WriteLine("Obj: {0} - {1} Equal: {2}",Obj,Obj2,Obj.Property==Obj2.Property);
    		
    	}
    }
