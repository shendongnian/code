    // Sample Class
    public class MyClass
    {
        public byte[] data;
    }
    // Main 
    static void Main(string[] args)
    {
        MyClass cls = new MyClass();
        using (SqlConnection cn = new SqlConnection("CONNECTION STRING"))
        {
            cn.Open();
            using (SqlCommand cmd = new SqlCommand("insert into MyTable values (@data)", cn))
            {
                cmd.Parameters.AddWithValue("@data", cls.data);
                cmd.ExecuteNonQuery();
            }
        }
    }
