    public abstract class BaseForm:Form{
            public SqlConnection getConnection()
            {
                SqlConnection conn = null; ;
                try
                {
                    conn = new SqlConnection("data source= DESKTOP-LKEG8FM\\SQLEXPRESS;initial catalog= PCJ_DB ; Integrated Security=True;");
                    conn.Open();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Can't Open Connection !" + ex);
                }
                return conn;
            }
    }
