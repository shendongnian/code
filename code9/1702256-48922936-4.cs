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
    
        prmNames.Append("@" + tArticle.Name);
        prms.Add("@p" + tArticle.Name, SqlDbType.NVarChar).Value = tArticle.Text;
        prmNames.Append("@" + tDesignation.Name);
        prms.Add("@p" + tDesignation.Name, SqlDbType.NVarChar).Value = tDesignation.Text;
    
        // Concat the parameters placeholders and close the query text
        sb.Append(string.Join(",", prmNames) + ")";
    
        // Pass everything to an utility method
        // This could be part of a bigger utility database class
        ExecuteInsertInto(sb.ToString(), prms);
    }
