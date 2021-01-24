    protected void Page_Load(object sender, EventArgs e) {
        string cs = ConfigurationManager.ConnectionStrings["CHTproductionConnectionString"].ConnectionString;
        int ImageID;
        string ImgTitle;
        string ImgDesc;
        string ImgBytes;
        string strBase64;
        if (!int.TryParse((string)Request.QueryString["ID"]), out ImageID) {
            // STOP: querystring is not a number
        } 
        else {
            using (SqlConnection con=new SqlConnection(cs)) {
                SqlCommand cmd = new SqlCommand("spGetImageId", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", ImageID);
                try {
                    con.Open();
                    var reader = cmd.ExecuteReader();
                    if (reader.Read()) {
                        ImgTitle = reader[0].ToString();
                        ImgDesc = reader[1].ToString();
                        ImgBytes = reader[2].ToString();
                        strBase64 = Convert.ToBase64String(ImgBytes);
                    }
                }
                catch (Exception ex) {
                    // handle exception
                }
                finally {
                    cmd.Dispose();
                    conn.Close();
                }
            }
        }
        if (strBase64 != null) {
            Image1.ImageUrl = "data:Image/png;base64," + strBase64;
            // utilize ImgTitle
            // utilize ImgDesc
        }
    }
