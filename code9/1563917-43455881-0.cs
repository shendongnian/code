    foreach (GridViewRow row1 in gvImage.Rows)
                    {
                        if (row1.RowType == DataControlRowType.DataRow)
                        {
                            string Id = gvImage.DataKeys[row1.RowIndex].Value.ToString();
                            ImageButton imgbtn = (ImageButton)gvImage.Rows[row1.RowIndex].FindControl("Image2");
                            string filename = imgbtn.ImageUrl;
        
                            TextBox ftype = (row1.FindControl("txtFileType") as TextBox);
                            
                            byte[] bytes = (byte[])GetData("SELECT BData FROM Employee WHERE Id =" + txt_StaffId.Text).Rows[0]["BData"];
                            string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                            imgbtn.ImageUrl = "data:image/png;base64," + base64String;
                          
                            {
                              
                                string constr = ConfigurationManager.ConnectionStrings["CONNECTION"].ConnectionString;
                                using (SqlConnection con8 = new SqlConnection(constr))
                                {
                                    string query = "insert into SShare (FId,UDetails,ShareBy,ShareByUserId,BData,ImageName, FileType) values(@FId,@UDetails,@ShareBy,@ShareByUserId,@BData,@ImageName,@FileType)";
        
                                    using (SqlCommand cmd8 = new SqlCommand(query))
                                    {
        
                                        cmd8.Parameters.AddWithValue("@FId", txt_Tester.Text);
                                        cmd8.Parameters.AddWithValue("@UDetails", TextBox1.Text);
                                        cmd8.Parameters.AddWithValue("@ShareBy", txt_StaffId.Text);
                                        cmd8.Parameters.AddWithValue("@ShareByUserId", txt_Employee.Text);
                                        cmd8.Parameters.AddWithValue("@BData", bytes);
                                     
                                        cmd8.Parameters.AddWithValue("@ImageName", filename);
                                        cmd8.Parameters.AddWithValue("@FileType", ftype.Text);
        
                                        con8.Open();
                                        // cmd8.ExecuteNonQuery();
                                        this.ExecuteQuery(cmd8, "SELECT");
        
                                        con8.Close();
                                    }
        
        
                                }
                            }
                        }
                    }
