    string file_name = Path.GetFileName(FileUpload1.FileName);
                string Excel_path = Server.MapPath("~/Excel/" + file_name);
                FileUpload1.SaveAs(Excel_path);
                OleDbConnection my_con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Excel_path + ";Extended Properties=Excel 8.0;Persist Security Info=False");
                my_con.Open();         
                OleDbCommand command = new OleDbCommand("select * from [Sheet1$]", my_con);          
                OleDbDataReader dr = command.ExecuteReader();
                dr.Read();            
                while (dr[0].ToString() != String.Empty)
                {
                ex_id = dr[0].ToString();
                string ex_uid = dr[1].ToString();
                //get second row data and assign it ex_name variable
                string ex_date = dr[2].ToString();
                //get thirdt row data and assign it ex_name variable
                string ex_dir = dr[3].ToString();
                //get first row data and assign it ex_location variable
                string ex_email = dr[4].ToString();
                string ex_email1 = dr[5].ToString();
                string ex_email2 = dr[6].ToString();
                //string ex_company = dr[7].ToString();
                string ex_company = dr[7].ToString();
                string ex_contact = dr[8].ToString();
                string ex_proposal = dr[9].ToString();
                string ex_reason = dr[10].ToString();
                   ...............
                   //Insert operation
                   ...............
                dr.Read();
                }
                dr.close();
                my_con.close();
