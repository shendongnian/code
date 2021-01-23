     var criteria = new Dictionary<string, Func<MyUser, boolean>>{
        { "criterion1", user => user.Property1==1 },
        { "criterion2", user => user.Property1!=1 && user.Property2=5 },
        //...
     }
     foreach (var criterion in criteria){
       var avg = data.Where(criterion.Value).Average(user => user.Testval);
       var count = data.Where(criterion).Count();
       Console.WriteLine($"{criterion.Key} average: {avg}, count: {count}");
     }
