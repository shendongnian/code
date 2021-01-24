    Document extendedDocument = Globals.Factory.GetVstoObject(Globals.ThisAddIn.Application.ActiveDocument);
    Word.Selection currentSelection = Globals.ThisAddIn.Application.Selection;
    Word.Paragraph para;
    para = extendedDocument.Content.Paragraphs.Add(ref oMissing);
    para.Range.SetRange(currentSelection.Range.Start, currentSelection.Range.End);
    string string1 = "one two three";
    string split1 = " ";
    string match1 = "two";
    string[] elements = Regex.Split(string1, split1);
    foreach (var m in elements)
    {
        if (m.Equals(match1))
        {
            para.Range.Text = m + " ";
            para.Range.Font.Italic = 1;
        }
        else 
        {
            para.Range.Text = m + " ";
            para.Range.Font.Italic = 0;
        }
        para.Range.InsertParagraphAfter();
    }
