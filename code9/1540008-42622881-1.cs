    public sealed class MyClass
    {
       public string NewFunction(string jsonstring)
       {
           JsonArray entity= JsonArray.Parse(jsonstring); 
           return entity.ToString();           
       }
    }
