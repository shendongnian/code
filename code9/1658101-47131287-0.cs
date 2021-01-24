    Document doc = new Document();
        Section sec = doc.AddSection();
        Paragraph para = sec.AddParagraph();
        string s = "<p><span style=\"font-size:11.0pt; font-family:Calibri;\">ABCD</span><br></p><p>Some other text</p> ";
        para.AppendHTML(s);
        foreach (var item in para.Items)
        {
            if(item is TextRange)
            { 
            TextRange tr = item as TextRange;
            tr.CharacterFormat.ClearFormatting();
            }
        }
        ParagraphStyle p1 = new ParagraphStyle(doc);
        p1.Name = "StylePara1";
        p1.CharacterFormat.TextColor = Color.Red;
        p1.CharacterFormat.FontSize = 50; 
        p1.CharacterFormat.FontName = "Arial Narrow";
        doc.Styles.Add(p1);
        para.ApplyStyle(p1.Name);
        doc.SaveToFile(fp.ResultPath + "AppendHtmlSegment.docx", FileFormat.Docx);
 
