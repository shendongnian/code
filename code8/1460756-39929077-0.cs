        private static string GetRelativeAddress(Range cell, Range range)
        {
            int startRow = range.Row;
            int startColumn = range.Column;
            int endRow = range.Row + range.Rows.Count - 1;
            int endColumn = range.Column + range.Columns.Count - 1;
            if (cell.Row >= startRow && cell.Row <= endRow &&
                cell.Column >= startColumn && cell.Column <= endColumn)
            {
                return $"R{cell.Row - startRow + 1}C{cell.Column - startColumn + 1}";
            }
            return String.Empty;
        }
