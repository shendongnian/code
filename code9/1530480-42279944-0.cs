        private void printDocument_nahlad_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
                // prvy štitok
                // prvy stlpec
                e.Graphics.DrawString(dataGridView_nahlad.Columns[0].HeaderText.ToString(), new Font("Microsoft Sans Serif", 12, FontStyle.Bold), Brushes.Black, new Point(75,55));
                e.Graphics.DrawString(dataGridView_nahlad.Rows[0].Cells[0].FormattedValue.ToString(), new Font("Microsoft Sans Serif", 12, FontStyle.Bold), Brushes.Black, new Point(150, 55));
                e.Graphics.DrawString(dataGridView_nahlad.Columns[1].HeaderText.ToString(), new Font("Microsoft Sans Serif", 12, FontStyle.Bold), Brushes.Black, new Point(75, 75));
                e.Graphics.DrawString(dataGridView_nahlad.Rows[0].Cells[1].FormattedValue.ToString(), new Font("Microsoft Sans Serif", 12, FontStyle.Bold), Brushes.Black, new Point(150, 75));
                // druhy stlpec
                e.Graphics.DrawString(dataGridView_nahlad.Columns[5].HeaderText.ToString(), new Font("Microsoft Sans Serif", 12, FontStyle.Bold), Brushes.Black, new Point(290, 55));
                e.Graphics.DrawString(dataGridView_nahlad.Rows[0].Cells[5].FormattedValue.ToString(), new Font("Microsoft Sans Serif", 12, FontStyle.Bold), Brushes.Black, new Point(350, 55));
                e.Graphics.DrawString(dataGridView_nahlad.Columns[6].HeaderText.ToString(), new Font("Microsoft Sans Serif", 12, FontStyle.Bold), Brushes.Black, new Point(290, 75));
                e.Graphics.DrawString(dataGridView_nahlad.Rows[0].Cells[6].FormattedValue.ToString(), new Font("Microsoft Sans Serif", 12, FontStyle.Bold), Brushes.Black, new Point(350, 75));
                // treti stlpec
                e.Graphics.DrawString(dataGridView_nahlad.Columns[9].HeaderText.ToString(), new Font("Microsoft Sans Serif", 12, FontStyle.Bold), Brushes.Black, new Point(450, 55));
                e.Graphics.DrawString(dataGridView_nahlad.Rows[0].Cells[9].FormattedValue.ToString(), new Font("Microsoft Sans Serif", 12, FontStyle.Bold), Brushes.Black, new Point(520, 55));
                e.Graphics.DrawString(dataGridView_nahlad.Columns[10].HeaderText.ToString(), new Font("Microsoft Sans Serif", 12, FontStyle.Bold), Brushes.Black, new Point(450, 75));
                e.Graphics.DrawString(dataGridView_nahlad.Rows[0].Cells[10].FormattedValue.ToString(), new Font("Microsoft Sans Serif", 12, FontStyle.Bold), Brushes.Black, new Point(520, 75));
                // vykreslenie čiar
                e.Graphics.DrawLine(new Pen (Brushes.Black, 3), 75 ,190,740,190);
                e.Graphics.DrawLine(new Pen(Brushes.Black, 3), 75, 45, 740, 45);
                //CODE FOR MY IMAGE
               // Bitmap bm = (Bitmap)dataGridView_nahlad.Rows[0].Cells[12].Value;
                //e.Graphics.DrawImage(bm, 620, 55, 120, 120);
           }
