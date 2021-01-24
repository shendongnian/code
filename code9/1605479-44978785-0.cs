    linqRows.ForEach(rowElement =>
    {
        intCol = 0;
        currentRow = dt.Rows.Add();
        rowElement.Descendants(ssNs + "Cell")
            .ToList<XElement>()                    
            .ForEach(cell => 
            {
                int cellIndex = 0;
                XAttribute indexAttribute = cell.Attribute(ssNs + "Index");
    
                if (indexAttribute != null)
                {
                    Int32.TryParse(indexAttribute.Value, out cellIndex);
                    intCol = cellIndex - 1;
                }
    
                currentRow[intCol] = cell.Value;
                intCol++;
            });
    });
