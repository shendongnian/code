    ContentControls controls = doc.SelectContentControlsByTitle("logo");
    
    foreach (ContentControl contentControl in controls)
    {
        var cc = contentControl.Range.InlineShapes.AddPicture("imageLocation");
    }
