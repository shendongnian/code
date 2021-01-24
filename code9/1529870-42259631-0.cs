        private void DeleteCell()
        {
            AllEmptyCells = ws.Cells().Where(w => String.IsNullOrEmpty(w.Value.ToString())).ToList();
            
            foreach(var item in AllEmptyCells.Reverse<IXLCell>())
            {
                ws.Cell(item.Address.RowNumber, item.Address.ColumnNumber).Delete(XLShiftDeletedCells.ShiftCellsLeft);
            }
        }
