        public Fill()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
            DataGridViewColumn dgvcol = new DataGridViewTextBoxColumn();
            dgvcol.DataPropertyName = "SubDtoId";
            dataGridView1.Columns.Add(dgvcol);
            dgvcol = new DataGridViewTextBoxColumn();
            dgvcol.DataPropertyName = "SubDtoLabel";
            dataGridView1.Columns.Add(dgvcol);
            dgvcol = new DataGridViewTextBoxColumn();
            dgvcol.DataPropertyName = "Caract";
            dataGridView1.Columns.Add(dgvcol);
            dgvcol = new DataGridViewTextBoxColumn();
            dgvcol.DataPropertyName = "Serial";
            dataGridView1.Columns.Add(dgvcol);
            dgvcol = new DataGridViewTextBoxColumn();
            dgvcol.DataPropertyName = "Comment";
            dataGridView1.Columns.Add(dgvcol);
            dataGridView1.DataSource = ListOfClasses();
        }
        public List<DTO> ListOfClasses()
        {
         //Sql query to return the List of DTO
        }
