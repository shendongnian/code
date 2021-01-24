        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            timer1.Enabled = true;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            string filter = txtbox_mobileno.Text;
            Thread t = new Thread(() => {
                cmd.CommandText = "SELECT  TOP 20 MobileNo FROM Customer WHERE MobileNo LIKE '" + filter + "%'";
                SqlDataReader dr;
                dr = RunSqlReturnDR(cmd);//return value
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        C.Add(dr[0].ToString()); //AutoCompleteStringCollection C = new AutoCompleteStringCollection();
                    }
                }
                dr.Close();
                txtbox_mobileno.Invoke((MethodInvoker)delegate {
                    txtbox_mobileno.AutoCompleteMode = AutoCompleteMode.Suggest;
                    txtbox_mobileno.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    txtbox_mobileno.AutoCompleteCustomSource = C;
                });
            });
            t.Start();
        }
