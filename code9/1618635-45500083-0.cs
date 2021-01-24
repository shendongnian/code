    public Form1()
    {
        InitializeComponent();
        sqlDataSource1.Fill();
        
    }
    
    private void button1_Click(object sender, EventArgs e)
    {
        gridControl1.Print();
    }
    
    private void gridView1_PrintInitialize(object sender, DevExpress.XtraGrid.Views.Base.PrintInitializeEventArgs e)
    {
        PrintingSystemBase pb = e.PrintingSystem as PrintingSystemBase;
        pb.StartPrint -= pb_StartPrint;
        pb.StartPrint +=pb_StartPrint;
       
    
    }
    
    void pb_StartPrint(object sender, PrintDocumentEventArgs e)
    {
        e.PrintDocument.PrinterSettings.Duplex = System.Drawing.Printing.Duplex.Horizontal;
        //e.PrintDocument.PrinterSettings.PrintToFile = true;
        e.PrintDocument.PrinterSettings.PrinterName = "Foxit Reader PDF Printer";
        
    }
