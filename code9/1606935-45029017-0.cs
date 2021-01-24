    string con = "Data Source=(DESCRIPTION =(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST = 000.00.0.00)(PORT = 0000)))(CONNECT_DATA =(SERVICE_NAME = database)));User ID=User/Schema;Password=password;Unicode=True";
    public void BindComboBox()
    {
        SqlConnection con = new SqlConnection(@"server=ServerName; database = DBName ;  User Id=sa; Password=PeaTeaCee5#");
        con.Open();
        string strCmd = "select desire column from table";
        SqlCommand cmd = new SqlCommand(strCmd, con);
        SqlDataAdapter da = new SqlDataAdapter(strCmd, con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        cmd.ExecuteNonQuery();
        con.Close();
    
        cbSupportID.DisplayMember = "name to display";
        cbSupportID.ValueMember = "id";       
        cbSupportID.DataSource = ds;
    
        cbSupportID.Enabled = true;
    
    }
