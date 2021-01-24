    public void GetData(string path)
            {
    
                int count = 0;
    
                DeskTokens = new List<Token>();
    
                SmartXLS.WorkBook WB = new WorkBook();
                WB.readCSV(path);
    
                DataTable dt = WB.ExportDataTable();
    
                string CurrentType = string.Empty;
                string CurrentCategory = string.Empty;
    
                DataRow dr;
                for (int i = 1; i < dt.Rows.Count; i++)
                {
                    dr = dt.Rows[i];
                    var tkn = new Token();
    
                    tkn.Product_name = dr[0].ToString();
                    tkn.Product_Version = dr[1].ToString();
                    tkn.Userid = dr[2].ToString();
                    tkn.User_name = dr[3].ToString();
    
                    DeskTokens.Add(tkn);
                    count++;
                    Console.WriteLine("Read : " + count);
    
                    Console.WriteLine("    Reading : " + tkn.Product_name + "," + tkn.Product_Version + "," + tkn.Userid + "," + tkn.User_name);
    
                }
            }
