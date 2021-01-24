        private void btnPrint_Click(object sender, EventArgs e) {
            var d = new PrintPreviewDialog();
            d.Document = new PrintDocument();
            d.Document.PrintPage += Dd_PrintPage;
            remainingText = rtbEditor.Text;
            var res = d.ShowDialog();
            try { if (res == DialogResult.OK) d.Document.Print(); }
            catch { }
        }
        string remainingText;
        private void Dd_PrintPage(object sender, PrintPageEventArgs e){
            //this code was for 1 page
            //e.Graphics.DrawString(rtbEditor.Text,new Font("Comic Sans MS", 12f),Brushes.Black,new PointF(10,10));
            //this is for multiple pages
            PrintDocument p = ((PrintDocument)sender);
            var font = new Font("Times New Roman", 12);
            var margins = p.DefaultPageSettings.Margins;
            var layoutArea = new RectangleF(
                margins.Left,
                margins.Top,
                p.DefaultPageSettings.PrintableArea.Width - (margins.Left + margins.Right),
                p.DefaultPageSettings.PrintableArea.Height - (margins.Top + margins.Bottom));
            var layoutSize = layoutArea.Size;
            layoutSize.Height = layoutSize.Height - font.GetHeight(); // keep lastline visible
            var brush = new SolidBrush(Color.Black);
            int charsFitted, linesFilled;
            // measure how many characters will fit of the remaining text
            var realsize = e.Graphics.MeasureString(
                remainingText,
                font,
                layoutSize,
                StringFormat.GenericDefault,
                out charsFitted,  // this will return what we need
                out linesFilled);
            // take from the remainingText what we're going to print on this page
            var fitsOnPage = remainingText.Substring(0, charsFitted);
            // keep what is not printed on this page 
            remainingText = remainingText.Substring(charsFitted).Trim();
            // print what fits on the page
            e.Graphics.DrawString(
                fitsOnPage,
                font,
                brush,
                layoutArea);
            // if there is still text left, tell the PrintDocument it needs to call 
            // PrintPage again.
            e.HasMorePages = remainingText.Length > 0;
        }
