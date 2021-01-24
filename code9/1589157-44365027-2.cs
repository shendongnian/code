    private void myCLASS_Load(object sender, EventArgs e)
    {
        myDataGridView.DataSource = (from x in _context.Students
        orderby x.MFlowOrdering
        select new { 
                    StudentsId = x.StudentsID, 
                    StudentsCode = x.StudentsCode, 
                    StudentsName = x.StudentsName
        }).ToList();                                      
    }
    private void myDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
      dynamic SelectedRow = myDataGridView.CurrentRow.DataBoundItem;
      MessageBox.Show(SelectedRow.StudentsID);
    }
