       var items = new List<string>() { "Item 1", "Item 2", "Item 3" };
        var formattedItems = string.Join(", ", items.ToArray());
        
        var dropDownRange = workSheet.Range["A2"];
        dropDownRange.Validation.Delete();
        dropDownRange.Validation.Add(Excel.XlDVType.xlValidateList,
        	Excel.XlDVAlertStyle.xlValidAlertInformation,
        	Excel.XlFormatConditionOperator.xlBetween,
        	formattedItems,
        	Type.Missing);
        	
        dropDownRange.Value = "Item 2";
