    private void printPreview_PrintClick(object sender, EventArgs e)
    {
        try
        {
            printDialog.Document = printDocument;
            
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument.PrinterSettings = printDialog.PrinterSettings;
                printDocument.Print();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, ToString());
        }
    }
