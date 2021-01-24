    string nspace = "...";
    var q = from t in typeof(SomeClassInTheAssembly).Assembly.GetTypes()
            where t.IsClass && t.Namespace == nspace
            select t;
    q.ToList().ForEach(t => Console.WriteLine(t.Name));
