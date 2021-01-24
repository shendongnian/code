     [SQLiteFunction(Arguments = 1, FuncType = FunctionType.Scalar, Name = "Lower")]
        class CustomLower : SQLiteFunction
        {
            public override object Invoke(object[] args)//characters for the growth of
            {
                return args[0].ToString().ToLower();
            }
        }
    
        [SQLiteFunction(Arguments = 2, FuncType = FunctionType.Scalar, Name = "CHARINDEX")]
        class CustomCharIndex : SQLiteFunction
        {
            public override object Invoke(object[] args)//characters for the growth of
            {
                return args[1].ToString().IndexOf(args[0].ToString(), StringComparison.Ordinal) + 1;
            }
        }
