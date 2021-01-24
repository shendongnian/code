    for (row = 1; row < 10; row++) 
    {
         string r;
         for (col = 1; col < 6; col++)
         {
             r += " " + ws.Cells[row, col].Value2;
         }
         listBox1.Items.Add(r.Trim());
         r = string.Empty;
    }
