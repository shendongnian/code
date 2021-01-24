    public void PrintDocument()
    {
        try
        {              
                PrintDocument pd = new PrintDocument();
                pd.PrintPage += new PrintPageEventHandler
                   (this.printDocument1_PrintPage);
                pd.Print();            
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
