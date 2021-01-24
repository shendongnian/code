    printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
    {
        // figure out how you're selecting an image
        // this selects the highlighted row
        int rowIndex = dataGridView1.CurrentCell.RowIndex;
        // select the image column
        Bitmap bm = (Bitmap) dataGridView1.Rows[rowIndex].Cells[0].Value;
        e.Graphics.DrawImage(bm, 0, 0);     
    }
