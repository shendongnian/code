    DataTable dt = new DataTable();
                    using (Conn)
                    {
                        SqlDataAdapter ad = new SqlDataAdapter("SELECT QuestionID, Images2.ImageID, ImageFile, ImageContent, ImageName, SEQ_NUM from qimages join Images2 on qimages.imageid = images2.imageid where QuestionID = @QuestionID", Conn);
                        ad.SelectCommand.Parameters.Add("QuestionID", SqlDbType.BigInt).Value = txt_QuestionID.Text;
                        ad.Fill(dt);
                    }
                    dlImages.DataSource = dt;
                    dlImages.DataBind();
