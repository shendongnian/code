    public void DVPrintDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
    {
         Printing print = new Printing(ticketingSystem);
         print.PrintPageHandler(sender, e);
    }
