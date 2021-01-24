    StringBuilder queryBuilder = new StringBuilder("Select * from country Where 1=1 ");
    SqlCommand cmdSql = new SqlCommand();
    
    if (combobox1.selectedindex > -1) 
    {
       queryBuilder.Append(" And city_name = @city_name "); 
       cmdSql.Parameters.Add("@city_name", SqlDbType.VarChar).Value = combobox.text;  
    }
    else if(Condition 2)
    {
       queryBuilder.Append(" And column2 = @col2 "); 
       cmdSql.Parameters.Add("@col2", SqlDbType.VarChar).Value = "some Value here;  
    }
    // Build the query like this
    cmdSql.CommandText= = queryBuilder.ToString();
    cmdSql.Connection = conObject;
    // Here you can execute the command
