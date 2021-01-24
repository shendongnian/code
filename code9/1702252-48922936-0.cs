    // Where you build the query text
    StringBuilder sb = new StringBuilder();
    // The placeholders for the parameters to be used
    List<string> prmNames = new List<string>();
    // The parameter collection 
    List<SqlParameter> prms = new List<SqlParameter>();
    // Initial text for the query
    sb.Append("INSERT INTO myTable (ArticleCode, Designation) VALUES (");
    // Loop over the textbox preparing the parameters placeholders and the collection
    foreach (TextBox tb in panelBE.Controls.OfType<TextBox>())
    {
        prmNames.Append("@" + tb.Name);
        prms.Add("@p" + tb.Name, SqlDbType.NVarChar).Value = tb.Text;
    }
    // Concat the parameters placeholders and close the query text
    sb.Append(string.Join(",", prmNames) + ")";
    // Pass everything to an utility method
    // This could be part of a bigger utility database class
    ExecuteInsertInto(sb.ToString(), prms);
