    System.Drawing.Printing.PrintDocument printDoc = new System.Drawing.Printing.PrintDocument();
    ArrayList paperSizes = new ArrayList();
    
    for (int i = 0; i < printDoc.PrinterSettings.PaperSizes.Count; i++)
    {
       paperSizes.Add(printDoc.PrinterSettings.PaperSizes[i]);
    }
    paperSizes.sort();
    listBox1.DataSource = paperSizes;
    listBox1.DisplayMember = "PaperName";
    listBox1.ValueMember = "Kind";
