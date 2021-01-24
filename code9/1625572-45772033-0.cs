    public void dataGridClientsLoad()
                {
                    DataTable dt = new DataTable();
        
                    dt = serviceSqlite.select(new Pacients());
        
                    dataGridView1.DataSource = dt;
                    dataGridView1.DataBind();//This require to bind data table.  
                   
                    label1.Text = "Все" + updateCountRows();
        
                }
