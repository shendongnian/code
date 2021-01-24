    protected void DownloadBtn_Click(object sender, EventArgs e)
        {
            string[] downloads = TxtDownloads.Text.Substring(1).Split(new char[] { ',' });
            StringBuilder builder = new StringBuilder();
            builder.Append("SchemeCode, SchemeCodeDescr, OwningCompany, PrimaryManagingCompany, ManagingCompany,RentAccountManagment\n");
    
            foreach (string downloadItem in downloads)
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand("spR_CSVDownload", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Id", downloadItem);
                        con.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            reader.Read();
                            string entry = "\"" + reader["SchemeCode"].ToString() + "\",";
                            entry += "\"" + reader["SchemeCodeDescr"].ToString() + "\",";
                            entry += "\"" + reader["OwningCompany"].ToString() + "\",";
                            entry += "\"" + reader["PrimaryManagingCompany"].ToString() + "\",";
                            entry += "\"" + reader["ManagingCompany"].ToString() + "\",";
                            entry += "\"" + reader["RentAccountManagment"].ToString() + "\"\n";
    
                            builder.Append(entry);
                        }
                        else { builder.Append("no item found for this one " + downloadItem + "\n");  }
                    }
    
                }
            }
            Response.Clear();
            Response.ContentType = "text/csv";
            Response.AddHeader("content-disposition", "attachment;filename=download.csv");
            Response.Write(builder.ToString());
            Response.End();
        }   
    }
