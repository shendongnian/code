    public List<HimHer.Models.Stories> GetAllImages()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString))
                {
                    SqlCommand sqlcom = new SqlCommand("Select * from Images", con);
                    SqlDataAdapter adp = new SqlDataAdapter(sqlcom);
                    con.Open();
                    SqlDataReader dt = sqlcom.ExecuteReader();
                    List<HimHer.Models.Stories> list = new List<Stories>();
                    Stories st = new Stories();
                    while (dt.Read()) 
                    {
                        st.Image = dt["Image"].ToString();
                        st.Story = dt["Story"].ToString();
                        list.Add(st);
                    }
                    return list;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
