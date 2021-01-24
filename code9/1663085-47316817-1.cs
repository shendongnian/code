    try
    {
        int x = int.Parse(datagridview.Rows[e.RowIndex].Cells[UserID.Index].Value.ToString());
        string query = "delete from productable where UserID=" + x;
        // now delete execute procedure
        MessageBox.Show("Deleted Successfully");
        // write code to bring record again.
    }
    catch(Exception ex)
    {
        MessageBox.Show(ex.StackTrace);
    }
