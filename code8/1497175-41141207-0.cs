     public class ExcelAddress
        {
            public readonly string LabelCell;
            public readonly string ColumnAddress;
            public readonly int ColumnAddressNumber;
            public readonly int RowAddressNumber;
            public readonly string RowAddress;
            public readonly string CellAddress; // this will give you address
    
            public ExcelAddress(int colNum, int rowNum, string Label)
            {
                ColumnAddressNumber = colNum;
                ColumnAddress = ExcelCellAddressConvertor.FromIntegerIndexToColumnLetter(ColumnAddressNumber);
                RowAddressNumber = rowNum;
                RowAddress = RowAddressNumber.ToString();
                LabelCell = Label;
                CellAddress = ColumnAddress + RowAddress;
            }
        }
