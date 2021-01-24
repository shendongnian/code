    namespace ConsoleApp6
    {
        class Program
        {
            static void Main(string[] args)
            {
                MyClass myObject = new MyClass();
                ListProperties(myObject.GetType(), 2);
                Console.ReadLine();
            }
    
            static void ListProperties(Type type, int ident)
            {
                var x = type.GetProperties();
                Console.WriteLine(new String(' ', ident) + "Class: " + type.FullName);
                int newIdent = ident += 2;
                x.ToList().Where(item => item.PropertyType.IsClass).ToList().ForEach(item => ListProperties(item.PropertyType, newIdent));
                
            }
        }
    
        class MyClass
        {
            public SubClass PropertySubClass1 { get; set; }
    
            public SubClass PropertySubClass2 { get; set; }
    
        }
    
        class SubClass
        {
            public SubSubClass PropertySubSubClass { get; set; }
        }
    
        class SubSubClass
        {
    
        }
    }
