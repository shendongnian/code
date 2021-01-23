    private void printPreview_PrintClick(object sender, EventArgs e)
    {
        try
        {
            printDialog1.Document = printDocument1;
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, ToString());
        }
    }
