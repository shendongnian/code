    SheetProperties _oPageSetupProperties = new SheetProperties(new PageSetupProperties());
    newWorksheetPart.Worksheet.SheetProperties = _oPageSetupProperties;
    
    // Set the FitToPage property to true
    newWorksheetPart.Worksheet.SheetProperties.PageSetupProperties.FitToPage = BooleanValue.FromBoolean(true);
    
    //set fitto width and height
    PageSetup pageSetup = new PageSetup();
    pageSetup.Orientation = OrientationValues.Landscape;
    pageSetup.FitToWidth = 1;
    pageSetup.FitToHeight = 50;
    newWorksheetPart.Worksheet.AppendChild(pageSetup);
