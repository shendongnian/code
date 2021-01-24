      private void btnsearch_Click(object sender, EventArgs e)
            {
                SqlConnection con = new SqlConnection("server = 192.168.100.6;Database=sms;UID=sa;Password=1234;");
    string sSql=@"Select id as 'Book ID',name as 'Name' , 
               Case when status=0 then 'unavailable' else 'available '
               End as 'Status' from 
               book where Name ='"+txtFirstName.Text +"'" 
                SqlCommand cmd = new SqlCommand(sSql, con); 
                try
                {
        
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
        
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    
                    dataGridView1.DataSource = dt;
                }
                catch (Exception ec)
                {
                    MessageBox.Show(ec.Message);
                }
        
            //    chage_value();
                dataGridView1.Show();
        
            }
        
        }
