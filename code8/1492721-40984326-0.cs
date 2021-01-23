    var doc =  richTextBox.Document;
    foreach(var c in evt.Changes.Where(x => x.AddedLength > 1))
    {
        var change = new TextRange(
            doc.ContentStart.GetPositionAtOffset(c.Offset),
            doc.ContentStart.GetPositionAtOffset(c.Offset + c.AddedLength));
        Debug.WriteLine($"Change: <{change.Text}>");                
    }
