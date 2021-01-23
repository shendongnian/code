    private static Image[] _imgs;
    
    //==========================================================================================================
        //CONVERT PICTURES TO PDF Button Click
        //==========================================================================================================
        private void button2_Click(object sender, EventArgs e)
        {
    
            // set the directory to store the output.
            string newdirectory = string.Format(@"C:\{0}", Case_No);
    
            // generate a file name as the current date/time in unix timestamp format
            string newFileName = "5 x 7 in";
    
            try
            {
    
                    // initialize PrinterDocument object
                    PrintDocument pd = new PrintDocument()
                    {
    
                        //Printer Settings
                        PrinterSettings = new PrinterSettings()
                        {
                            // set the printer to 'Microsoft Print to PDF'
                            PrinterName = "Microsoft Print to PDF",
    
                            // tell the object this document will print to file
                            PrintToFile = true,
    
                            // set the filename to whatever you like (full path)
                            PrintFileName = Path.Combine(newdirectory, newFileName + ".pdf"),
    
                        }//End Printer settings
    
    
                    };//End PrintDocument()
    
    
                pd.PrintPage += new PrintPageEventHandler(this.pd_PrintPage);
                pd.Print();
    
            }//End try 
    
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
    
        }//End Button Module   
    
    
    public static void Page_Init(object sender, EventArgs e)
    {
      if(!IsPostBack)
         BuildImageList();
    
    }
    
    
        //===========================================
        // Print Event Handler
        //===========================================
        private void pd_PrintPage(object sender, PrintPageEventArgs ev)
        {
    
            Graphics graphic = ev.Graphics;
            Point p = new Point(10, 10);
            Image img = _imgs[index];
            graphic.DrawImage(img, p);
            index++;
            ev.HasMorePages = index < _imgs.Length;
            img.Dispose();
    
        }
    
    
        //===============================================
        // Get Build the Image List
        //===============================================
    
        public static void BuildImageList()
        {
            String sdira = @"C:\test";
            _imgs = System.IO.Directory.GetFiles(sdira, "*.JPG").Select(f => Image.FromFile(f)).ToArray();
        }
