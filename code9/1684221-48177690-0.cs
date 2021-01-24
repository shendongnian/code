    var text = row[3].ToString();
    var lines = text.Split(
        new[] { '\r', '\n' },
        StringSplitOptions.RemoveEmptyEntries);
    foreach (var line in lines)
    {
        var p = txtAreaText.CaretPosition;
        txtAreaText.BeginChange();
        p.InsertTextInRun(line);
        p = p.InsertParagraphBreak();
        txtAreaText.EndChange();
        txtAreaText.CaretPosition = p;
    }
