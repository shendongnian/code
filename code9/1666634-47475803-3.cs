    // Register your type
    EvalManager.DefaultContext.RegisterType(typeof(MyRow));
    
    // Register extension methods once from Z.EntityFramework.Plus
    EvalManager.DefaultContext.RegisterExtensionMethod(typeof(BatchUpdate));
    
    Eval.Execute("query.Update(x => new MyRow() { Id = 1, Name = 'Z_Name', Qunatity = 2});", new {query});
