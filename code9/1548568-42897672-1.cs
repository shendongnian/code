    private void button2_Click(object sender, EventArgs e)
            {
             try
                {
                DataTable dt = new DataTable();
                dt = service.searchCom(textBox1.Text);
                if(dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        textBox2.Text = row["CompanyName"].ToString();
                        textBox3.Text = row["balance"].ToString();
                        textBox4.Text = row["maintBalance"].ToString();
                        textBox2.ReadOnly = true;
                        textBox3.ReadOnly = true;
                        textBox4.ReadOnly = true;
                        button1.Visible = false;
                        Back.Visible = true;
                    }
                }
               }
             catch (SoapException ex)
             {
                if(ex.Actor == "SoapException")
                  //Do something
             }    
            }
