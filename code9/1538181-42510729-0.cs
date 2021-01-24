    List<Microsoft.Office.Interop.PowerPoint.Shape> pptShapes = new List<Microsoft.Office.Interop.PowerPoint.Shape>();
    for (int jCurr = 1; jCurr <= slide.Shapes.Count; jCurr++)
                    {                        
                        currShp = slide.Shapes[jCurr];
                        pptShapes.Add(currShp);
                    }
    string deletedString = "";
    //Do something else like delete a few of the shapes
    if (slide.Shapes[1] != null)
    {
         string deletedString = pptShapes[0].Type.ToString();
         slide.Shapes[1].Delete();
    }
    
    //Below gives me Null since I deleted the original shape
    MessageBox.Show(deletedString);
