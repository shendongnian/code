    // Get the list you want into a cell range
    worksheet.Range("A1:A3").Value = listFormats;
    // Reference the range when applying the validation
    rng.Validation.Delete();
    rng.Validation.Add(... xlBetween, worksheet.Range("A1:A3").Address);
