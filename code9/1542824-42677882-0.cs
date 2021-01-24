    //Preparing parameterized query to avoid SQL injection.
    var sqlQuery = "select * from Tokens where  (YEAR(Convert(datetime,Time,5)) % 100) = @year	AND MONTH(Convert(datetime,Time,5)) = @month";
    
    //Preparing command and adding parameters with the values.
    var sqlCommand = new SqlCommand();
    sqlCommand.CommandText = sqlQuery;
    sqlCommand.Parameters.Add("@year", textBox1.Text);
    sqlCommand.Parameters.Add("@month", textBox2.Text);
