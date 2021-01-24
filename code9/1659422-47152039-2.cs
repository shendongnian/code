     if (dataGridView1.Rows[j].DefaultCellStyle.BackColor ==System.Drawing.Color.Yellow)
     {
          int nextRowIndex = j + 1; // the code works up to one cell.  
          while (dataGridView1.Rows[nextRowIndex].DefaultCellStyle.BackColor == System.Drawing.Color.Green)
          {
              dataGridView1.Rows[nextRowIndex++].Cells[2].Value = dataGridView1.Rows[j].Cells[2].Value;
          }
    }
