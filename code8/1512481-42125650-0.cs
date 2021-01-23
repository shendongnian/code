    public static string GetCellV(Cell cell, SharedStringTable ss)
        {
            string cellV = null;
            try
            {
                cellV = cell.CellValue.InnerText;
                if (cell.DataType != null
                  && cell.DataType.Value == CellValues.SharedString)
                {
                    cellV = ss.ElementAt(Int32.Parse(cellV)).InnerText;
                }
                else
                {
                    cellV = cell.CellValue.InnerText;
                }
            }
            catch (Exception)
            {
                cellV = " ";
            }
            return cellV;
        }
