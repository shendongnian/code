        /// <summary>
        /// Gets number of rows this cell occupies.
        /// </summary>
        /// <param name="headerFwidths">The fwidths of the headers of the table this cell belongs to</param>
        /// <param name="index">The column index of the cell to check</param>
        /// <param name="cCell">The cell to check</param>
        /// <returns>int the number of rows</returns>
        public int GetRowLines(float[] headerFwidths, int index, CellValue cCell) {
            float tableWidth = Document.GetRight(Document.LeftMargin);
            float lPad = cCell.PaddingLeft != null ? cCell.PaddingLeft.Value : 2f;
            float rPad = cCell.PaddingRight != null ? cCell.PaddingRight.Value : 2f;
            float maxFloatPerRow = ((tableWidth / headerFwidths.Sum()) * headerFwidths[index]) - (lPad + rPad);
            string content = string.IsNullOrEmpty(cCell.Title) ? string.Empty : cCell.Title;
            int rowLines = 0;
            float cellFontWidth = BaseFont.GetWidthPoint(content, cCell.CellFont.Size);
            rowLines = (int)Math.Ceiling(cellFontWidth / maxFloatPerRow);
            return rowLines == 0 ? 1 : rowLines;
        }
