     private void button1_Click(object sender, EventArgs e)
        {
            short numCopies = 0;
            numCopies = Convert.ToInt16(textBox2.Text);
            
            PrintDocument printDocument = new PrintDocument();
            printDocument.DefaultPageSettings.Landscape = true;
            printDocument.DefaultPageSettings.PaperSize = new PaperSize("zed", 400, 850 );
            printDocument.PrinterSettings.Copies = numCopies;
            printDocument.PrintPage += PrintDocumentOnPrintPage;
            printDocument.Print();
        }    
