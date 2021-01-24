     ScriptEngine engine = Python.CreateEngine();
     ScriptScope scope = engine.ExecuteFile("FindProducts.py");
     dynamic products = scope.GetVariable("products");
     foreach (dynamic product in products)
     {
        Console.WriteLine("{0}: {1}", product.ProductName, product.Price);
     }
