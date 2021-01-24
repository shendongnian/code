        private void btn_save_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlConn = new SqlConnection(@"Data Source=desktop-ndocu0t\sqlexpress;Initial Catalog=MetinShop;Integrated Security=True"))
            {
                using (SqlCommand sqlComm = new SqlCommand("INSERT INTO Bank1 (accref, deposit, psID) VALUES (@accref, @deposit, @psID)", sqlConn))
                {
                    if (sqlComm.Connection.State == ConnectionState.Closed)
                        sqlComm.Connection.Open();
                    string accref = tb_accref.Text;
                    int deposit = Convert.ToInt32(tb_depamount.Text);
                    int psID = Convert.ToInt32(tb_personalID.Text);
                    sqlComm.Parameters.AddWithValue("@accref", accref);
                    sqlComm.Parameters.AddWithValue("@deposit", deposit);
                    sqlComm.Parameters.AddWithValue("@psID", psID);
                    sqlComm.ExecuteNonQuery();
                    MessageBox.Show("Transition Updatet Sucessfully");
                }
            }
        }
