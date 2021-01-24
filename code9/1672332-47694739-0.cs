    Query qry = Product.CreateQuery().WHERE("ListPrice > 50.00")
                .AND("Class = L").AND("Color = Yellow");
    using(IDataReader rdr = qry.ExecuteReader())
    {
     while (rdr.Read()) {
       Console.WriteLine(rdr[Product.Columns.Name].ToString());
     }
    }
