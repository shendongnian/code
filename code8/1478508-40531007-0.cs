    int count = 0;
    foreach (Microsoft.Office.Interop.Word.HeaderFooter OHeader in documentOld.Sections[1].Headers)
    {
        foreach (Microsoft.Office.Interop.Word.Shape shape in OHeader.Shapes)
        {
            if (shape.Name.Contains("Text Box"))
            {
                ++count;
            }
        }
    }
