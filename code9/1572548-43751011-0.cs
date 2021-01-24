                    using (SqlDataReader read = cmd.ExecuteReader())
                    {
                        if (read.HasRows)
                        {
                            while (read.Read())
                            {
                                textBoxICPass.Text = (read["icnum"].ToString());
                                textBoxPassport.Text = (read["passport"].ToString());
                                textBoxDept.Text = (read["deptno"].ToString());
                                textBoxSection.Text = (read["section"].ToString());
                            }
                        }
                        else
                        {
                            lblError.Text = "No Data Found";
                        }
                    }
                }
