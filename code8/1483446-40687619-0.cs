    private PrintDocument printDoc;
    private PrintPreviewDialog printPreview;
    List<string> elements = new List<string>();
    private int ElementCounter;
    private int page;
    printDoc.BeginPrint += PrintDoc_BeginPrint;
    printDoc.PrintPage += PrintDoc_PrintPage;
    private void PrintDoc_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
    {
        page = 0;
    }
    private void PrintDoc_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
    {
        e.Graphics.DrawImage(Image.FromFile(elements[page]), e.MarginBounds);
        page++;
        e.HasMorePages = page < elements.Count;
    }
    private void btn_Print_Click(object sender, EventArgs e)
    {
        DirectoryInfo directory = new DirectoryInfo(@"C:\image\Shared_Directory\Printing_Folder\");
        FileInfo[] Files = directory.GetFiles("*.tif"); //Getting Tif files
        foreach (FileInfo file in Files)
        {              
            elements.Add(file.Name);
            ElementCounter++;
        }
        printPreview.Document = printDoc;
        printPreview.Show();
    }
