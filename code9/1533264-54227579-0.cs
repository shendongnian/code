    private void checkuserifexist()
    {
    MySqlConnection con = new MySqlConnection("SERVER=localhost; user id=root; password=; database=databasename");
    con.Open();
    try
    {
    MySqlCommand cmd = con.CreateCommand();
    cmd.CommandText = "SELECT * FROM login where ID='" + txtid.Text + "'";
    MySqlDataReader exist = cmd.ExecuteReader();
    if(exist.HasRows)
    {
    login();
    }
    else
    {
    MessageBox.Show("This user doesn't Exist", "ID not exist", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }
    //login code
    private void login()
    {
    MySqlConnection con = new MySqlConnection("SERVER=localhost; user id=root; password=; database=databasename");
    con.Open();
    String strusername = txtusername.Text;
    String strpassword = txtpassword.Text;
    string sql = "SELECT * FROM login WHERE Username='" + strusername + "'AND Password='" + strpassword + "'";
    MySqlDataAdapter da = new MySqlDataAdapter(sql, con);
    DataTable ds = new DataTable();
    da.Fill(ds);
    for(int i = 0; dt.Rows.Count; i++)
    {
    if(dt.Rows[i]["Userlevel"].Equals("Administrator"))
    {
    this.Hide();
    Admin admin = new Admin();
    admin.ShowDialog();
    }
    }
    }
