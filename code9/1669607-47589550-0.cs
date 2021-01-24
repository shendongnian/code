    foreach (Publish p in tempstructure)
    {
        if (p.element_type_id == 3)
        {                
           selection.set_Style(Word.WdBuiltinStyle.wdStyleHeading2);
           selection.TypeText(p.name);
           selection.TypeParagraph();
        }
        else
        {
            if (File.Exists(@Properties.Settings.Default.documentsPath + p.filename + "_" + language + ".docx"))
            {
                selection.InsertFile(@Properties.Settings.Default.documentsPath + p.filename + "_" + language + ".docx");
                selection = word.Selection;
            }
            else
            {
                selection.TypeText("Missing file: " + p.filename + "_" + language + ".docx");
                selection.TypeParagraph();
            }
        }
        selection = word.Selection;
    }
