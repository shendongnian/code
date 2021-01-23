    if (FileUpload.HasFile)
    {
    string path = string.Concat(Server.MapPath("~/Excel/" + FileUpload.FileName));
    FileUpload.SaveAs(path);
    string constr = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=Excel 8.0", path);
    ITransaction trans = Data.Instance.NHibernateSession.BeginTransaction();
        using (OleDbConnection conn = new OleDbConnection(constr))
        {
            conn.Open();
            OleDbCommand command = new OleDbCommand("Select * from [Sheet$]", conn);
            OleDbDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Relation relation = new Relatie();
                    try
                    {
                      
                      relation.name = reader[0].ToString();
                      relation.function = reader[1].ToString();
                      relation.Email = reader[2].ToString();
                      // Save to DB
                   }
                   catch(SqlException ex)
                   {
                      // Get the data from relation object
                   }
                }
            }
            trans.Commit();
        }
         File.Delete(path);
    }
