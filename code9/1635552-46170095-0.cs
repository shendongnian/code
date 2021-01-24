    private void GView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
    
        try
        {
            string cellValue = GView.Rows[e.RowIndex].Cells["NAME"].Value.ToString();
    
            var confirmResult = MessageBox.Show("delete this item " + cellValue,
                                             "Confirm Delete!!",
                                              MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                System.IO.FileInfo fi = new System.IO.FileInfo(cellValue);
                fi.Delete();
            }
            else
            {
    
            }
        }
        catch(System.IO.IOException)
        {
         // exception when file is in use or any other
        }
        catch (UnauthorizedAccessException ex)
        {
            MessageBox.Show(ex.Message);
        }
       catch(Exception ex)
       {
        // all other
       }
    
    }
