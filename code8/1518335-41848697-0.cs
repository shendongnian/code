    Microsoft.Office.Interop.PowerPoint.Shape editedShape;
    long editedShapeID;
    foreach (Microsoft.Office.Interop.PowerPoint.Shape slideShape in slide.Shapes)
    {
        if (slideShape.HasTextFrame == Microsoft.Office.Core.MsoTriState.msoTrue)
        {
            editedShape = slideShape;
            var textFrame = slideShape.TextFrame;
            if (textFrame.HasText == Microsoft.Office.Core.MsoTriState.msoTrue)
            {
                 var textRange = textFrame.TextRange;
                 pps += slideShape.TextFrame.TextRange.Text;
                 foreach (char word in textRange)
                 {
                     l.Add(word);
                     Debug.WriteLine(word);
                 }
             }
         }
         editedShapeID = editedShape.Id;
         editedShapesListID.Add(editedShpeID);
    }
