    private void printRow(int rowIndex, float printX, float printY, float lineIncrement, PrintPageEventArgs e) {
      for (int col = 0; col < dataGridView1.ColumnCount; col++) {
        string text = dataGridView1[col, rowIndex].FormattedValue.ToString();
        e.Graphics.DrawString(text, font, Brushes.Black, new PointF(printX, printY));
        printY += lineIncrement;
      }
    }
