     foreach (Row r in sheetData.Elements<Row>())
        {
            foreach (Cell c in r.Elements<Cell>())
            {
                if (GetColumnName(c.CellReference) == "A")
                {
                string text = c.CellValue.InnerText;
                }
            }
        }
