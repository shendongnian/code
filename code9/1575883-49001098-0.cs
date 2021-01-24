    private void dgv1()//show patient table
        {
            dataGridView1.Columns["id"].DisplayIndex = 0;
            dataGridView1.Columns["name"].DisplayIndex = 1;
            dataGridView1.Columns["gender"].DisplayIndex = 2;
            dataGridView1.Columns["age"].DisplayIndex = 3;
            dataGridView1.Columns["phone"].DisplayIndex = 4;
        }
     public void patientTableView() 
        {           //add to dataGridView
            Service1Client ptn = new Service1Client();
            dataGridView1.DataSource = ptn.GetpatientTable();
            
        }
    private void Form1_Load(object sender, EventArgs e)
        {//call the method when form loading
            patientTableView();
            
        }
