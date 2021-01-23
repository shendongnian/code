    string stuImg  = string.Empty;       
             SqlConnection con2 = new SqlConnection(conString);
                con2.Open();
                if (con2.State == System.Data.ConnectionState.Open)
                {
                    string sss = "SELECT student_photo from student_reg where  reg_year='" + year + "'and s_id='" +sid_lbl.Text+ "'";
                    SqlCommand cmd = new SqlCommand(sss, con2);
                    Console.WriteLine(sss);
                    SqlDataReader dr4 = cmd.ExecuteReader();
                    while (dr4.Read())
                    {
                        stuImg =dr4["student_photo"].ToString();
                    }
                    var pic = Convert.FromBase64String(stuImg);
                    using (MemoryStream ms = new MemoryStream(pic))
                      {
                       picturebox1.Image = Image.FromStream(ms);
                      }
                  }
