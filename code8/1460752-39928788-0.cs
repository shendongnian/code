    public void NewClass()
    {
        try
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("create database "+dbnm,con);
            cmd.ExecuteNonQuery();
            cmd.Cancel();cmd.Dispose();
            con.Close();con.Dispose();
            con = new SqlConnection("Data Source=DESKTOP-0R1BJNQ\\HARDIKPATEL;Initial Catalog="+dbnm+";Integrated Security=True");
            con.Open();
            cmd = new SqlCommand("CREATE TABLE dbo.MyTable (ID int IDENTITY(1,1) PRIMARY KEY,MyProduct nvarchar(100) NOT NULL,MyDateTime datetime NOT NULL)", con);
            cmd.ExecuteNonQuery();
            cmd.Cancel();cmd.Dispose();
            con.Close();con.Dispose();
        }
        catch(Exception err)
        {
            lblmsg.Text = err.ToString();
        }
    }
