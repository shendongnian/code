    public void NewClass()
    {
        try
        {
            string query = "if exists(SELECT db_id('{0}'),'TEST') ";
            query += "begin ";
            query += "print 'All Ready Exists' ";
            query += "end ";
            query += "else ";
            query += "begin ";
            query += "create database TEST ";
            query += "end ";
            lblno.Text = query+"<br>";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            int ans = cmd.ExecuteNonQuery();
            cmd.Cancel(); cmd.Dispose();
            con.Close(); con.Dispose();
            string table = "if exists (select OBJECT_ID('test')) begin ";
            table += "print 'all ready' end ";
            table += "else begin ";
            table += "CREATE TABLE dbo.MyTable (ID int IDENTITY(1,1) PRIMARY KEY,MyProduct nvarchar(100) NOT NULL,MyDateTime datetime NOT NULL) ";
            table += "end ";
            con = new SqlConnection("Data Source=DESKTOP-0R1BJNQ\\HARDIKPATEL;Initial Catalog=" + dbnm + ";Integrated Security=True");
            con.Open();
            cmd = new SqlCommand(table, con);
            cmd.ExecuteNonQuery();
            cmd.Cancel(); cmd.Dispose();
            con.Close(); con.Dispose();
        }
        catch(Exception err)
        {
            lblmsg.Text = err.ToString();
        }
    }
