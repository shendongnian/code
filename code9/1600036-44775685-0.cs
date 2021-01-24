    using (var cells = worksheet.CellsUsed(c => c.GetString() == "V"))
    {
        foreach (var cell in cells)
        {
            // Do something with the cell ...
        }
    }
