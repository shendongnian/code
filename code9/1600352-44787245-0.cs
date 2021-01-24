    public static void Broken()
    {
        var parameters = ((IEnumerable<dynamic>)Data).Select(x => new DynamicParameters(x));
        var parametersList = parameters.ToList(); // you create a list
        parametersList.ForEach(x => x.AddDynamicParams(new {Bax = 7})); // then you modify that list
        // parametersList != parameters
        
        using (var connection = new SqlConnection(""))
        {
            // This fails with a "Must declare scalar variable @Bax".
            connection.Execute("INSERT INTO DataTable(Foo, Bar, Bax) VALUES(@Foo, @Bar, @Bax)", parameters); // but here you are passing the old parameters collection
        }
    }
