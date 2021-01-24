    string file_name = Path.GetFileName(FileUpload1.FileName);
        string Excel_path = Server.MapPath("~/Excel/" + file_name);
        DataTable dtExceldata = new DataTable();
        FileUpload1.SaveAs(Excel_path);
        OleDbConnection my_con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Excel_path + ";Extended 
    Properties=Excel 8.0;Persist Security Info=False");
            OleDbDataAdapter da = new OleDbDataAdapter("select * from [Sheet1$]", my_con);
            da.Fill(dtExceldata);
            if(dtExceldata.Rows.Count>0)
            {
                for (int i = 0; i <= dtExceldata.Rows.Count - 1; i++)
                {
                    //assign value to variable
                    //like below
                    //string ex_uid = dtExceldata.Rows[i]["columnName"]; 
                    //then insert operation here
    
                }
        }
