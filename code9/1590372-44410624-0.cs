         string[] Columns = new[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
    
     public String getExcelAddress(int row, int column)
            {
                string cellAddress = "";
                cellAddress = ((column / 26) - 1 >= 1 ? Columns[(column / 26) - 1] : "") + Columns[column % 26] + (row + 1);
                return cellAddress;
            }
    
            public String getTablePosition(DataTable dataTable, String value)
            {
                for (int rows = 0; rows < (dataTable.Rows.Count < 100 ? dataTable.Rows.Count : 100); rows++)
                {
                    for (int cols = 1; cols < (dataTable.Columns.Count < 100 ? dataTable.Columns.Count : 100); cols++)
                    {
                        if (dataTable.Rows[rows].ItemArray[cols].ToString().Trim() == value.Trim())
                        {
                            return getExcelAddress(rows, cols);
                        }
                    }
                }
                return "";
            }
