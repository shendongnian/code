        var people = table.CreateSet<Person>(ConvertMethod);
    
    ..... //return type is the same as you want and method takes a Tablerow as a parameter
        public static Person ConvertMethod(TableRow row)
        {
            return new Person()
            {
                FirstName = row["firstName"],
                LastName = row["surname"]
            };
        }
