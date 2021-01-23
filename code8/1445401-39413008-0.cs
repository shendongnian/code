    string cs4 = ConfigurationManager.ConnectionStrings["example"].ConnectionString;
                StringBuilder sb4 = new StringBuilder();
                using (SqlConnection con4 = new SqlConnection(cs4))
                {
                    StreamWriter file4 = new StreamWriter(@"\\Desktop" + todaysDate + ".csv", true);
                    string strTQuery = @"SELECT * FROM [dbo].[view]";
                    SqlDataAdapter da4 = new SqlDataAdapter(strTQuery, con4);
                    DataSet ds4 = new DataSet();
                    da4.Fill(ds4);
                    ds4.Tables[0].TableName = "Example";
                    foreach (DataRow exDR in ds4.Tables["Example"].Rows)
                    {
                        sb4 = new StringBuilder();
                        sb4.Append(exDR["A"].ToString() + strDelimiter);
                        sb4.Append(exDR["B"].ToString() + strDelimiter);
                        sb4.Append(exDR["C"].ToString() + strDelimiter);
                        sb4.Append(exDR["D"].ToString());
                        sb4.Append("\r\n");
                        file4.WriteLine(sb4.ToString());
                    }
                    file4.Close();
                }
                
