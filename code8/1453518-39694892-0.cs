     string _fname,_fpath;
                    if (FileUpload1.HasFile)
                    {
                       _fname = FileUpload1.FileName.ToString();
                       _fpath="~/upload/"+_fname.ToString();
                        FileUpload1.SaveAs(Server.MapPath("~/upload/") + _fname);
                        SqlCommand cmd = new SqlCommand("insert into tablename(Name,Image) values('" + TextBox1.Text + "','" + _fpath + "')", con);
                        cmd.CommandType = CommandType.Text;
                        try
                        {
                            con.Open();
                            cmd.ExecuteNonQuery();
                            Label1.Text = "Data inserted successfully";
                            con.Close();
                            TextBox1.Text = "";
                        }
                        catch (Exception ex)
                        {
                            Label1.Text = ex.Message;
                        }
                    }
