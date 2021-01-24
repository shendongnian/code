    DataGridView1_CellLeave(Object sender, DataGridViewCellEventArgs e)
    {
        if (e.ColumnIndex == 0)
        {
            //DoStuff when leave first datagrid's column
        }
    }
    DataGridView1_KeyDown(Object sender, System.Windows.Forms.KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Shift)
        {        
            //You can do stuff on DataGridView1.CurrentCell when Shift is pressed
        }
    }
