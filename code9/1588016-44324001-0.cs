    public static void InsertData(string connectionstring, string matnummer, string bezeichnung, string format, string grammatur, string gewicht, string eform, string kuvertierung, string altkuvert)
    {
        string check = "Select COUNT(*) FROM dbo.Material where DPMatNr = @matnummer";
        string query = "Insert INTO dbo.Material (DPMatNr, DPBezeichnung)" + "VALUES (@matnummer, @bezeichnung)";
        string query2 = "Insert INTO dbo.Eigenschaften (EigenschaftenBezeichnerID, Wert)" + "VALUES (@1, @format, @2, @grammatur, @3, @gewicht, @4, @eform, @5, @kuvertierung, @6, @altkuvert)";
    
    
        using (SqlConnection cn = new SqlConnection(connectionstring))
        using (SqlCommand chkCom = new SqlCommand(check, cn))
        {
            cn.Open();
            chkCom.Parameters.Add("@matnummer", SqlDbType.VarChar, 50).Value = matnummer;
            int? matCnt = chkCom.ExecuteScalar() as int?;
    
            if (matCnt == 0 || matCnt == null)
            {
                 using (SqlCommand cmd = new SqlCommand(query, cn))
                 {
                      cmd.Parameters.Add("@matnummer", SqlDbType.VarChar, 50).Value = matnummer;
                      cmd.Parameters.Add("@bezeichnung", SqlDbType.VarChar, 50).Value = bezeichnung;
    
                      cmd.ExecuteNonQuery();
                 }
            }
    
            using (SqlCommand cmd2 = new SqlCommand(query2, cn))
            {
                 cmd2.Parameters.Add("@1", SqlDbType.Int).Value = 1;
                 cmd2.Parameters.Add("@format", SqlDbType.VarChar, 50).Value = format;
                 cmd2.Parameters.Add("@2", SqlDbType.Int).Value = 2;
                 cmd2.Parameters.Add("@grammatur", SqlDbType.VarChar, 50).Value = grammatur;
                 cmd2.Parameters.Add("@3", SqlDbType.Int).Value = 3;
                 cmd2.Parameters.Add("@gewicht", SqlDbType.VarChar, 50).Value = gewicht;
                 cmd2.Parameters.Add("@4", SqlDbType.Int).Value = 4;
                 cmd2.Parameters.Add("@eform", SqlDbType.VarChar, 50).Value = eform;
                 cmd2.Parameters.Add("@5", SqlDbType.Int).Value = 5;
                 cmd2.Parameters.Add("@kuvertierung", SqlDbType.VarChar, 50).Value = kuvertierung;
                 cmd2.Parameters.Add("@6", SqlDbType.Int).Value = 6;
                 cmd2.Parameters.Add("@altkuvert", SqlDbType.VarChar, 50).Value = altkuvert;
                 cmd2.ExecuteNonQuery();
    
             }
             cn.Close();
         }
    }
