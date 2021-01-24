    DataGridView dgv = new DataGridView();
    dgv.DataSource = YourDataTable;
    // hide the columns you dont want on grid
    dgv.Columns[0].Visible = false;
    dgv.Columns[2].Visible = false;
    dgv.Columns[3].Visible = false;
    dgv.Columns[4].Visible = false;
