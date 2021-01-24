    using System;
    using System.Diagnostics;
    using OC = Microsoft.Office.Core;
    using PP = Microsoft.Office.Interop.PowerPoint;
    string filePath = "C:/Temp/";
    string fileName = "Template.pptm";
    // Open PowerPoint in hidden mode, run the macro, and shut PowerPoint down
    var pptApp = new PP.Application();
    PP.Presentation presentation = pptApp.Presentations.Open(filePath + fileName, OC.MsoTriState.msoFalse, OC.MsoTriState.msoFalse, OC.MsoTriState.msoFalse);
    pptApp.Run(filename + "!.FixConnectors");
    presentation.Close();
    presentation = null;
    pptApp.Quit();
    pptApp = null;
    // Reopen the file through Windows
    Process.Start(filePath + fileName);
    // Clear all references to PowerPoint
    GC.Collect();
    GC.WaitForPendingFinalizers();
    GC.Collect();
    GC.WaitForPendingFinalizers();
