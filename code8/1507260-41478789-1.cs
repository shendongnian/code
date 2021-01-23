    string querySQL = "Select DocumentNo , Revision, DocumentTitle, DocumentType FROM DocumentLog WHERE IsDeleted='0'";
    using(SqlConnection conSQL = DBConnection.openConnection())
    {
        using(SqlCommand cmdSQL = new SqlCommand())
        {
            if(!string.IsNullOrEmpty(tbxDocumentNo.Text))
            {
                querySQL += "AND  DocumentNo Like @DocumentNo";
                cmdSQL.Parameters.Add("@DocumentNo", SqlDbType.VarChar).Value = "%" + tbxDocumentNo.Text + "%";
            }
            
            // Add rest of conditions here like this
        
            cmdSQL.CommandText=querySQL;
            cmdSQL.Connection = conSQL;
        SqlDataAdapter da = new SqlDataAdapter(cmdSQL);                                     
        }
    }
