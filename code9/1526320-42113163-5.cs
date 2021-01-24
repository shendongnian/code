    using System.Drawing.Printing;
    ...
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        PrintDocument pd = new PrintDocument();
        pd.PrintPage += PrintPage;
        pd.Print();       
    }
    private void PrintPage(object o, PrintPageEventArgs e)
    {
        System.Drawing.Image img = System.Drawing.Image.FromFile("D:\\Foto.jpg");
        Point loc = new Point(100, 100);
        e.Graphics.DrawImage(img, loc);     
    }
