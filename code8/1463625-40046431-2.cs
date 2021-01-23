    protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string sImageID = Request.QueryString["id"];
                string constr = ConfigurationManager.ConnectionStrings["CS1"].ConnectionString;
                string sQuery = "SELECT ImageFile from Images2 WHERE ImageID = @ImageID";
                SqlConnection con = new SqlConnection(constr);
                SqlCommand cmd = new SqlCommand(sQuery, con);
                cmd.Parameters.Add("@ImageID", SqlDbType.Int).Value = Int32.Parse(sImageID);
                using (con)
                {
                    con.Open();
                    SqlDataReader DR = cmd.ExecuteReader();
                    if (DR.Read())
                    {
                        byte[] imgData = (byte[])DR["ImageFile"];
                        Response.BinaryWrite(imgData);
                    }
                }
            }
        }
