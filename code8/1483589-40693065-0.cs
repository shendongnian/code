     public static String dbGetData(String q)
        {
            openConnection(); //opens connection if closed
            try
            {
                SqlCommand cmd = new SqlCommand(q, connection);
                return cmd.ExecuteScalar().ToString();
            }
            catch (Exception)
            {
            }
            return null;
        }
