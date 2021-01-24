      private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
      {
           List<string> values = new List<string>();
        
           foreach(object o in listBox1.Items)
               values.Add(o.ToString());
        
           string selectedItems = String.Join(",", values);
        
                    Bitmap bmp = Properties.Resources.Resibo;
                    Image newImage = bmp;
                    e.Graphics.DrawImage(newImage, 35, 35, newImage.Width, newImage.Height);
                    e.Graphics.DrawString("  Name :                     " + label3.Text, new Font("Arial", 18, FontStyle.Regular), Brushes.Black, new Point(30, 150));
                    e.Graphics.DrawString("  Requested :                " + selectedItems , new Font("Arial", 18, FontStyle.Regular), Brushes.Black, new Point(30, 200));
                    e.Graphics.DrawString("  Total :                    " + label2.Text, new Font("Arial", 18, FontStyle.Regular), Brushes.Black, new Point(30, 250));
      }
