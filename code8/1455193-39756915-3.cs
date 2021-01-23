    class Program
        {
            public static dynamic Dyn { get; set; }
    
            static void Main(string[] args)
            {
              dynamic model= new  CommandLineModelDictionary();
                model.Prop1 = "Foo";
                model.Prop2 = "toto";  
    
    
    
                 Console.WriteLine(model.Prop1);
                Console.WriteLine(model.Prop2);
                //otherwise you can use 
                dynamic dynModel = new ExpandoObject();
                dynModelop1 = "Test1";
                dynModel2 = "Test2";  
                Console.WriteLine(dynModel.Prop1);
                Console.WriteLine(dynModel.Prop2);
    
    
            }
        }
