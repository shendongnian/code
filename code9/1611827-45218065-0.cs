     public class NationalityInfo
        {
            public int ID { get; set; }
            public string Name { get; set; }// any Other           
        }
     [WebMethod]
        [ScriptMethod]
        public List<NationalityInfo> LoadNat()
        {
            string Conn = System.Configuration.ConfigurationManager.ConnectionStrings["GPS_TrackingConnectionString"].ConnectionString;
            List<NationalityInfo> NatInformation = new List<NationalityInfo>();
            DataSet ds;
            using (SqlConnection con = new SqlConnection(Conn))
            {
                using (SqlCommand cmd = new SqlCommand("select * from Nationality", con))
                {
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        ds = new DataSet();
                        da.Fill(ds);
                    }
                }
            }
            try
            {
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow dr in ds.Tables[0].Rows)
                            {
                                NatInformation.Add(new NationalityInfo()
                                {
                                    ID = Convert.ToInt32(dr["Id"]),
                                    Name = dr["Name"].ToString()                                    
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return NatInformation;
        }
