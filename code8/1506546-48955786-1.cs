    Visio.Document Document=App.Documents.OpenEx("D:\\Temp\\trees_top_with_shadow.dwg", Flags);
    int iCount = Document.Pages.Count;
    for (int i = 0; i < iCount; i++)
    {
        Microsoft.Office.Interop.Visio.Page page = Document.Pages.get_ItemFromID(i);                    
        page.Export("D:\\temp\\thejus" + i + ".svg"); //working
        page.Export("D:\\temp\\thejus" + i + ".bmp"); //working
    }
