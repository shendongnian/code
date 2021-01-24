    private float printRow(int rowIndex, float printX, float printY, float lineIncrement, int stopCol, PrintPageEventArgs e) {
      for (int col = 0; col < dataGridView1.ColumnCount; col++) {
        if (col < stopCol) {
          string text = dataGridView1[col, rowIndex].FormattedValue.ToString();
          e.Graphics.DrawString(text, font, Brushes.Black, new PointF(printX, printY));
          printY += lineIncrement;
        }
        else {
          break;
        }
      }
      return printY;
    }
