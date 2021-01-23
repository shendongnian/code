     static  void ExecuteFunction(Type T,string functionName, string Value)
            {
                MethodInfo m = ((T.GetTypeInfo()).DeclaredMethods.Where(x => x.Name == functionName).FirstOrDefault());
                //var customAttributes = (MyCustomAttribute[])((T.GetTypeInfo()).DeclaredMethods.Where(x => x.Name == functionName).FirstOrDefault()).GetCustomAttributes(typeof(MyCustomAttribute), true);
                var customAttributes = (MyCustomAttribute[])(m.GetCustomAttributes(typeof(MyCustomAttribute), true));
    
                if (customAttributes.Length > 0)
                {
                    var myAttribute = customAttributes[0];
                    string value = myAttribute.SomeProperty;
                    // TODO: Do something with the value
                    Console.WriteLine(value);
                    if (value == Value)
                    {
                        m.Invoke(null, null);
                    }
                    else
                        Console.WriteLine("Unauthorized");
                }
    
            }
