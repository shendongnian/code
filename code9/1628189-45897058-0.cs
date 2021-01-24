    private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ETA_Input frm = new ETA_Input(this);
            frm.ShowDialog();
            if (frm.time != 0)
            {
                string name = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                int deku = Int32.Parse(name);
                string constring = "server=localhost;database=dbhorizon;uid=root;password=1234";
                string Query = "update tblUserIdd set User_Available = 'Ongoing' where User_ID='" + deku + "' ";
                MySqlConnection conDatabase = new MySqlConnection(constring);
                MySqlCommand cmdDatabase = new MySqlCommand(Query, conDatabase);
                MySqlDataReader myReader;
                conDatabase.Open();
                myReader = cmdDatabase.ExecuteReader();
                dgvref();
                string id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                string naem = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                string field = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                f = frm.time;
                startTime = DateTime.Now;
                secondss = string.Format("{0:HH:mm:ss tt}", DateTime.Now);
                string[] row = { id, naem, field, secondss, frm.eta,custb, f.ToString()  };
                var listViewItem = new ListViewItem(row);
                listView1.Items.Add(listViewItem);
                
                
            }
               
        }
