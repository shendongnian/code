    public IEnumerable<GenderPieChart_Model> Gender()
        {
            List<GenderPieChart_Model> data = new List<GenderPieChart_Model>();
            using (SqlConnection con = new SqlConnection(Connection.MyConn()))
            {
                SqlCommand com = new SqlCommand("dbo.sp_Project_DashBoard 4", con);
                con.Open();
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    GenderPieChart_Model value = new GenderPieChart_Model();
                    value.GenderDesc = Convert.ToString(reader.GetValue(0));
                    value.GenderID = Convert.ToInt32(reader.GetValue(1));
                    data.Add(value);
                }
            }
            return data;
        }
