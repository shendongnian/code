    private void Print(string thetext){
    
                
                try
                {
    
                    System.Drawing.Printing.PrintDocument p = new System.Drawing.Printing.PrintDocument();
                     
                    var font = new Font("Times New Roman", 12); 
                    var brush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
    
                    // what still needs to be printed
                    var remainingText = theText;
    
                    p.PrintPage += delegate (object sender1, System.Drawing.Printing.PrintPageEventArgs e1)
                    {
                        int charsFitted, linesFilled;
    
                    // measure how many characters will fit of the remaining text
    
                    var realsize = e1.Graphics.MeasureString(
                            remainingText,
                            font,
                            e1.MarginBounds.Size, 
                            System.Drawing.StringFormat.GenericDefault,
                            out charsFitted,  // this will return what we need
                            out linesFilled);
    
                    // take from the remainingText what we're going to print on this page
                    var fitsOnPage = remainingText.Substring(0, charsFitted);
                    // keep what is not printed on this page 
                    remainingText = remainingText.Substring(charsFitted).Trim();
    
                    // print what fits on the page
                    e1.Graphics.DrawString(
                            fitsOnPage,
                            font,
                            brush,
                            e1.MarginBounds); 
    
                        // if there is still text left, tell the PrintDocument it needs to call 
                        // PrintPage again.
                        e1.HasMorePages = remainingText.Length > 0;
                    };
    
                    System.Windows.Forms.PrintDialog pd = new System.Windows.Forms.PrintDialog();  
                    pd.Document = p; 
                    DialogResult result = pd.ShowDialog();
    
                    if (result == System.Windows.Forms.DialogResult.OK)
                    {
                        p.Print();
                    } 
    
    
                }catch(Exception e2)
                {
                    System.Windows.MessageBox.Show(e2.Message, "Unable to print",MessageBoxButton.OK);
                }
    
    }
