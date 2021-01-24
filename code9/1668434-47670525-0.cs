            string fileName = @"YouPath";
            string conn = string.Empty;
            DataTable dtexcel = new DataTable();
            conn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileName 
            + ";Extended Properties='Excel 12.0;HDR=NO';"; //for above excel 
            2007 
             
            using (OleDbConnection con = new OleDbConnection(conn))
            {
                con.Open();
                DataTable Sheets = 
                con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                try
                {
                    OleDbDataAdapter oleAdpt = new OleDbDataAdapter("select * 
                    from [WorksheetName$]", con); //here we read data from 
                    sheet1  
                    oleAdpt.Fill(dtexcel); //fill excel data into dataTable  
                }
                catch (Exception ex)
                {
                }
            }
            return dtexcel;
