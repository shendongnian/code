    using(var con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
    {
        using(var com = new SqlCommand("insert into sanctuary(SName) values('test');", con)
        {
             con.Open();
             com.ExecuteNonQuery();
             com.CommandText = "insert into species(Name) values('test1');";
             com.ExecuteNonQuery();
             com.CommandText = "insert into breed(SpeciesID, BreedName, FoodCost, HousingCost)  SELECT SpeciesID, ('breed'), ('12'), ('21') FROM species;";
             com.ExecuteNonQuery();
        }
    }
