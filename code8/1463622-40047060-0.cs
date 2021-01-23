    private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView2.AutoGenerateColumns = false;
    //
    //Text Box column
            DataGridViewTextBoxColumn UserIDColumn = new DataGridViewTextBoxColumn();
            UserIDColumn.Name = "user_id";
            UserIDColumn.DataPropertyName = "user_id";
            UserIDColumn.HeaderText = "User ID";
            UserIDColumn.HeaderCell.Style.Font = new Font(dataGridView2.Font, FontStyle.Bold);
            UserIDColumn.ReadOnly = false;
            dataGridView2.Columns.Add(UserIDColumn);
    //Adding a combobox
            DataGridViewComboBoxColumn ActionStatusCodeColumn = new DataGridViewComboBoxColumn();
            ActionStatusCodeColumn.Name = "StatusCode";
            ActionStatusCodeColumn.DataPropertyName = "StatusCode";
            ActionStatusCodeColumn.ReadOnly = false;
            ActionStatusCodeColumn.DataSource = GetStatusLkp();//This function returns a BindingSource which contains the noted members below StatusCode and StatusCodeDescrEng.
            ActionStatusCodeColumn.ValueMember = "StatusCode";
            ActionStatusCodeColumn.DisplayMember = "StatusCodeDescrEng";
            dataGridView2.Columns.Add(ActionStatusCodeColumn);
    //Attach the Data property name to the columns
    dataGridView2.Columns[0].DataPropertyName = "user_id";
    dataGridView2.Columns[1].DataPropertyName = "StatusCode";
    //Next bind your DGV
    dataGridView2.DataSource = GetActionsData(); //This function returns a BindingSource which contains the noted members user_id and StatusCode.
    }
