    // This is assumed to be even
    TextBox[] txtArray = panelBE.Controls.OfType<TextBox>().ToArray();
    for(int x = 0; x < txtArray.Length; x+=2)
    {
        TextBox tArticle = txtArray[x];
        TextBox tDesignation = txtArray[x+1];
    
        // Where you build the query text
        StringBuilder sb = new StringBuilder();
    
        // The placeholders for the parameters to be used
        List<string> prmNames = new List<string>();
    
        // The parameter collection 
        List<SqlParameter> prms = new List<SqlParameter>();
    
        // Initial text for the query
        sb.Append("INSERT INTO myTable (ArticleCode, Designation) VALUES (");
    
        prmNames.Add("@" + tArticle.Name);
        prms.Add(new SqlParameter() 
        {
            ParameterName = "@p" + tArticle.Name,
            SqlDbType = SqlDbType.NVarChar,
            Value = tArticle.Text
        });
        prmNames.Add("@" + tDesignation.Name);
        prms.Add(new SqlParameter()
        {
             ParameterName = "@p" + tDesignation.Name,
             SqlDbType = SqlDbType.NVarChar,
             Value = tDesignation.Text
        });
        // Concat the parameters placeholders and close the query text
        sb.Append(string.Join(",", prmNames) + ")");
    
        // Pass everything to an utility method
        // This could be part of a bigger utility database class
        ExecuteInsertInto(sb.ToString(), prms);
    }
