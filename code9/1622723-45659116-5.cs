    var dType = MyTypeBuilder.CompileResultType("sample", new Dictionary<string, Type>
    {
    	{ "Id", typeof(int) }
    });
    var db = new Model1().Database;
    var sql = db.GetType().GetMethods().Where(m => m.Name == "SqlQuery" && m.IsGenericMethod);
    var gen = sql.First().MakeGenericMethod(dType);
    
    var result = gen.Invoke(db, new object[] { "[Your SQL]", new object[0] });
    var ie = (result as IEnumerable<object>);
