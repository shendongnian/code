    protected void Write_CSV_From_Recordset2(SqlDataReader oDataReader)
        {
            string strCSV = string.Empty;
    
            for (int i = 0; i < oDataReader.FieldCount; i++)
            {
                string tmpColumnName = oDataReader.GetName(i);
    
                strCSV += tmpColumnName + ',';
            }
    
            strCSV += "\r\n";
    
    
    
            while (oDataReader.Read())
            {
    
    
                for (int i = 0; i < oDataReader.FieldCount; i++)
                {
                    object item = oDataReader[i];
    
                    strCSV += item.ToString().Replace(",", ";") + ',';
    
                }
    
    
                strCSV += "\r\n";
    
            }
    
    
            //Download the CSV file.
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=pretestscore.csv");
            Response.Charset = "";
            Response.ContentType = "application/text";
            Response.Output.Write(strCSV);
            Response.Flush();
            Response.End();
    
    
        }
