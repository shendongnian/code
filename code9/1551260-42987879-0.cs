    Microsoft.Office.Interop.PowerPoint.Presentation objPres;
    int index = Int32.Parse(clickedIssue.ToolTip.ToString());
    
    objPres = Globals.ThisAddIn.Application.ActivePresentation;
    var slides = objPres.Slides;
                    
    slides[index].Select();
