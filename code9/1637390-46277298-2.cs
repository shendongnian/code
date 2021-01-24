    using Microsoft.Office.Interop.Word;
    var wordApp = new Application();
    var doc = wordApp.Documents.Open(chemin, ReadOnly: false, Visible: false);
    doc.Activate();
    
    foreach (Section sec in doc.Sections)
    {
        var range = sec.Footers[WdHeaderFooterIndex.wdHeaderFooterFirstPage].Range;
        var table = range.Tables[1];
    }
    doc.Close();
