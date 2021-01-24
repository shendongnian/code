    Document doc = new Document();
    
    // This truly makes the document empty. No sections (not possible in Microsoft Word).
    doc.RemoveAllChildren();
    
    // Create a new section node. 
    // Note that the section has not yet been added to the document, 
    // but we have to specify the parent document.
    Section section = new Section(doc);
    
    // Append the section to the document.
    doc.AppendChild(section);
    
    // Lets set some properties for the section.
    section.PageSetup.SectionStart = SectionStart.NewPage;
    section.PageSetup.PaperSize = PaperSize.Letter;
