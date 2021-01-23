    var hText = document.Paragraphs.Add();
    hText.Range.Text = solutionModel.Name; // <--
    hText.set_Style(Microsoft.Office.Interop.Word.WdBuiltinStyle.wdStyleHeading1);
    hText.Format.SpaceAfter = 10f;
    hText.Range.InsertParagraphAfter();
