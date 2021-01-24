    private void btn_save_Click(object sender, EventArgs e)
    {
        //objekti per konektim me DBne
        SqlConnection conn = new SqlConnection(@"Data Source=desktop-ndocu0t\sqlexpress;Initial Catalog=MetinShop;Integrated Security=True");
        conn.Open();
        string accref = tb_accref.Text;
        int deposit = Convert.ToInt32(tb_depamount.Text);
        int psID = Convert.ToInt32(tb_personalID.Text);
        //try all fields are string 
        string query = "INSERT INTO Bank1(accref, deposit, psID) Values('" + accref + "', '" + deposit + "', '" + psID + "')";
        //try last fields are numeric
        //string query = "INSERT INTO Bank1(accref, deposit, psID) Values('" + accref + "', " + deposit + ", " + psID + ")";
        SqlCommand command = new SqlCommand();
        command.Connection = conn;
        command.CommandText = query;
        command.ExecuteNonQuery()
              
        //mbylle lidhjen me DB
        conn.Close();
        MessageBox.Show("Transition Updatet Sucessfully");
    }
    private void btn_reset_Click(object sender, EventArgs e)
    {
        tb_accref.Text = "0";
        tb_depamount.Text = "0";
        tb_personalID.Text = "0";
        lblamount.Text = "0";
    }
    private void btn_exit_Click(object sender, EventArgs e)
    {
        Close();
    }
