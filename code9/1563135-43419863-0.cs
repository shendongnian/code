    public string AskBaseForPolishName(string englishName)
    {
        //it's best NOT to re-use the same connection object. Only reuse the same connection string
        using (var cn = new SqlConnection("connection string here"))
        using (var cmd = new SqlCommand("select Polish from Flashcard where English = @EnglishName;", cn))
        {
             cmd.Parameters.Add("@EnglishName", SqlDbType.NVarChar, 20).Value = englishName;
             cn.Open();
             return cmd.ExecuteScalar().ToString();
        }
    }
