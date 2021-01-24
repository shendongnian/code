    //(This example is uses WPF/System.Windows.DragDrop)
    //Create temporary file
    string fileName = "DragDropSample.txt";
    var tempPath = System.IO.Path.GetTempPath();
    var tempFilePath = System.IO.Path.Combine(tempPath, fileName);
    System.IO.File.WriteAllText(tempFilePath, "Testing drag and drop");
    //Create DataObject to drag
    DataObject dragData = new DataObject();
    dragData.SetData(DataFormats.FileDrop, new string[] { tempFilePath });
    //Initiate drag/drop
    DragDrop.DoDragDrop(dragSourceElement, dragData, DragDropEffects.Move);
