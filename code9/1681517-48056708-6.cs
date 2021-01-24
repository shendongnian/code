    [WebMethod]
    public static void SaveFrmDetails(User user)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["conndbprodnew"].ConnectionString;
        using (OracleConnection con = new OracleConnection(connectionString))
        {
            using (OracleCommand cmd = new OracleCommand("INSERT INTO TDC_PRODUCT1(PRODUCT_ID,TDC_NO, REVISION) VALUES (:PRODUCT_ID,:TDC_NO,:REVISION )", con))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue(":PRODUCT_ID", user.PRODUCT_ID);
                cmd.Parameters.AddWithValue(":TDC_NO", user.TDC_NO);
                cmd.Parameters.AddWithValue(":REVISION", user.REVISION);
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
    
                cmd.CommandText = "insert into Prop_detail(Tdc_no,Rowno,Prop_Name,Tdc_property) values(@tdN,@rowNo,@propN,@tdProp)";
                int rowNum = 1;// You can get rowNum from DB and initiate it to last rowNum
                foreach (WireDimDetail wireDimDetail in user.WireDimDetails)
                {
                    cmd.Parameters.Clear();
                    Dictionary<string, string> strNumbers = new Dictionary<string, int>()
                        {
                        {"sizMin",  wireDimDetail.SizeMin },
                        {"sizeMax" , !string.IsNullOrEmpty(wireDimDetail.SizeMax) ? wireDimDetail.SizeMax.ToString() : "0" },
                        {"tolMin",   wireDimDetail.TolMin.ToString() },
                        {"tolMax",   wireDimDetail.TolMax.ToString() }
                        }; 
                    cmd.Parameters.Clear();
                   
                    foreach (KeyValuePair<string, string> kvp in strNumbers)
                    {
                        cmd.Parameters.AddWithValue("@tdN", user.TDC_NO);
                        cmd.Parameters.AddWithValue("@rowNo", rowNum);
                        cmd.Parameters.AddWithValue("@propN", kvp.Key);
                        cmd.Parameters.AddWithValue("@tdProp", kvp.Value);
                        cmd.ExecuteNonQuery();
                        
                    }
                    rowNum++;
                }
                con.Close();
            }
        }
    }
