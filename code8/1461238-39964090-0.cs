    private void comboBox_suburb_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\WoolsValley\documents\visual studio 2015\Projects\WindowsFormsApplication17\WindowsFormsApplication17\mydatabase.mdf; Integrated Security = True");
            con.Open();
            int i = comboBox_suburb.SelectedIndex;
            int j = 1;
          
            comboBox_suburb.ValueMember = mydatabaseDataSet.Tables[0].Columns[1].ToString();
            if (comboBox_suburb.SelectedItem.ToString() == (mydatabaseDataSet.Tables[0].Rows[i][j].ToString())) ;
                {
                    int timetosub = Convert.ToInt32(mydatabaseDataSet.Tables[0].Rows[i][j + 1]);
              
                    totaltime = bdtime + timetosub;
                    tmpk = totaltime;
                    time3 = time2.AddMinutes(-tmpk);
                    textBox_ordertostart.Text = time3.ToString("hh:mm tt");
                }
        }
