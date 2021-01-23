    namespace WpfApplication1
    {
        public class VModel
        {
            public VModel()
            {
                DataTable dt = new DataTable();
                using (SqlConnection connection = new SqlConnection("your connection string to the database..."))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.SelectCommand = new SqlCommand("Select c_name, l_name, a_town, a_pcode, a_street from dbo.AllCustomers", connection);
                    adapter.Fill(dt);
                }
                AlleKunden = dt.DefaultView;
            }
            public DataView AlleKunden { get; private set; }
        }
    }
