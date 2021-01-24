    List<Microsoft.Office.Interop.PowerPoint.Shape> pptShapes = new List<Microsoft.Office.Interop.PowerPoint.Shape>();
    for (int jCurr = 1; jCurr <= slide.Shapes.Count; jCurr++)
                    {                        
                        currShp = slide.Shapes[jCurr];
                        pptShapes.Add(currShp);
                    }
    string deletedString = "";
    if (slide.Shapes[1] != null)
    {
         string deletedString = pptShapes[0].Type.ToString();
         slide.Shapes[1].Delete();
    }
    
    MessageBox.Show(deletedString);
