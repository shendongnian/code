    using (var conn = new SqlConnection(connectionStr))
    {
        conn.Open();
        using (var cmd = conn.CreateCommand())
        {
            var querySb = new StringBuilder(@"
                CREATE TABLE #temp (Token NVARCHAR(20) NOT NULL)");
            
            //tokensArray will contain texts from your text boxes
            for (int i = 0; i < tokensArray.Length; i ++)
            {
                querySb.Append($"INSERT INTO #temp VALUES(@p{i})");
                // parameterized query, to protect against SQL injection (input is coming from user)
                cmd.Parameters.AddWithValue($"@p{i}", $"%{token}%");
            }
            
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = querySb.ToString();
    
            querySb.Append(@"; 
    SELECT C.* 
    FROM customer C 
        JOIN #temp T ON C.FirstName LIKE T.Token";
    
            // execute stuff
        }
    }
