    public struct PersonStruct
    {
        public string Name {get; set;}    
    }
    
    delegate void FirstByRefAction<T1, T2>(ref T1 arg1, T2 arg2);
    void Main()
    {
    	ParameterExpression par1 = Expression.Parameter(typeof(PersonStruct).MakeByRefType());
    	ParameterExpression par2 = Expression.Parameter(typeof(string));
    	FirstByRefAction<PersonStruct, string> setter = Expression.Lambda<FirstByRefAction<PersonStruct, string>>(
    		Expression.Assign(Expression.Property(par1, "Name"), par2),
    		par1, par2
    		).Compile();
    	PersonStruct testStruct = new PersonStruct();
    	setter(ref testStruct, "Test Name");
    	Console.Write(testStruct.Name); // outputs "Test Name"
    }
