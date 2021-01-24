        private void button5_Click(object sender, EventArgs e)
        {
            if (excelApp != null && MyBook != null) //sanity check
            {
                MySheet = (Worksheet)MyBook.Sheets[1]; // Explicit cast is not required here
                MySheet.Cells[excelApp.ActiveCell.Row, excelApp.ActiveCell.Column] = total;
                MyBook.Save();
            }
        }
