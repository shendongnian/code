    private Microsoft.Office.Interop.Outlook.Application moOutlook = new Microsoft.Office.Interop.Outlook.Application();
    private void DragDropHandler(object sender, DragEventArgs e)
    {
        var loExplorer = moOutlook.ActiveExplorer();
        var loSelection = loExplorer.Selection;
    
        foreach (object loItem in loSelection)
        {
            Microsoft.Office.Interop.Outlook.ContactItem loContactItem = (loItem as Microsoft.Office.Interop.Outlook.ContactItem);
            if (loContactItem != null)
            {
                Console.WriteLine(loContactItem.EntryID);
                Console.WriteLine(loContactItem.Email1Address);
                Console.WriteLine(loContactItem.Email2Address);
            }
        }
    }
