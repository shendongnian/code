            private Row ConstructHeader(params string[] headers)
        {
            Row row = new Row();
            foreach (var header in headers)
            {
                row.AppendChild(ConstructCell(header, CellValues.String));
            }
            return row;
        }
        private Cell ConstructCell(string value, CellValues dataType)
        {
            return new Cell()
            {
                CellValue = new CellValue(value),
                DataType = new EnumValue<CellValues>(dataType),
            };
        }
        private Cell ConstructCell(string value, string cellReference, CellValues dataType)
        {
            return new Cell()
            {
                CellReference = cellReference,
                CellValue = new CellValue(value),
                DataType = dataType,
            };
        }
