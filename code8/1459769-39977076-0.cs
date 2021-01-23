     PageMargins pageM = sheetPart.Worksheet.GetFirstChild<PageMargins>();
                       SheetProtection sheetProtection = new SheetProtection();
                       sheetProtection.Password = "admin";
                       sheetProtection.Sheet = true;
                       sheetProtection.Objects = true;
                       sheetProtection.Scenarios = true;
                       ProtectedRanges pRanges = new ProtectedRanges();
                       ProtectedRange pRange = new ProtectedRange();
                       ListValue<StringValue> lValue = new ListValue<StringValue>();
                       lValue.InnerText = ""; //set cell which you want to make it editable
                       pRange.SequenceOfReferences = lValue;
                       pRange.Name = "not allow editing";
                       pRanges.Append(pRange);
                       sheetPart.Worksheet.InsertBefore(sheetProtection, pageM);
                       sheetPart.Worksheet.InsertBefore(pRanges, pageM);
        
