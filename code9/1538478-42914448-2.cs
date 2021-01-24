    var mapper = config.CreateMapper();
    var output = new ClassA
    {
        objClassB = new ClassB
        {
            objListofData = new ListOfData 
            {
                Employee = new []
                   {
                        new Employee  { FirstName = "David", LastName ="Peter" }
                   }
            }
        }
    };
                
    var destMap = mapper.Map<DestClassA>(output);
