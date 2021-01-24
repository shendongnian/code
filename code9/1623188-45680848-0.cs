     private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
     { 
        // set index to be the pic column, assume that pic in column 0
        int index = 0;
        // just check that the clicked cell is the right cell
        // and every thing is okay.
 
        if (dataGridView.CurrentCell.ColumnIndex.Equals(index) && e.RowIndex != -1)
        if (dataGridView.CurrentCell != null && dataGridView.CurrentCell.Value != null)
        {
            // cast to image
            Bitmap img = (Bitmap)dataGridView.CurrentCell.Value;
            
            // load image data in memory stream
            MemoryStream ms = new MemoryStream();
            img.save(ms, ImageFormat.Jpeg);
            
            // now you can open image in any picBox by memory stream.
            // if you want to open pic in other form, you need to pass memory 
            // stream to this form, e.g., in constructor.
            // open other form
            NewForm obj = new NewForm(ms)
        }
     }
