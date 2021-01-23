    var method = typeof(IFoo).GetMethod(nameof(IFoo.Get));
    var generic = method.MakeGenericMethod(typeof(IBar));
    var task = (Task<IBar>)generic.Invoke(foo, new [] { bar2 });
    
    var resultProperty = task.GetProperty("Result");
    var result = resultProperty.GetValue(task);
    var convertedResult = Convert.ChangeType(result, bar2.GetType()); 
