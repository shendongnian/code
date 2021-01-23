    StringBuilder sqlCommandText = new StringBuilder();
    
    sqlCommandText.Append("Select DocumentNo , Revision, DocumentTitle, DocumentType FROM DocumentLog WHERE IsDeleted = 0");
    
    if(!string.IsNullOrEmpty(tbxRevision.Text))
    {
        sqlCommandText.Append(" AND Revision Like @revision");
        command.Parameters.Add("@revision", tbxRevision.Text);
    }
    
    // do this for all fields
     
    command.CommandText = sqlCommandText.ToString();   
