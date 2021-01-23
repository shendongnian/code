    private void DataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
    {
        using (Brush customColor = new SolidBrush(Color.Red))
        using (Brush cellDefaultBrush = new SolidBrush(e.CellStyle.ForeColor))
        {
            if (e.Value != null && !string.IsNullOrEmpty(e.Value.ToString()) && e.RowIndex != -1)
            {
                string fullText = e.Value.ToString();
                string firstChar = fullText[0].ToString();
                string restOfTheText = fullText.Substring(1);
    
                e.PaintBackground(e.CellBounds, true);
                Rectangle cellRect = new Rectangle(e.CellBounds.Location, e.CellBounds.Size);
                Size entireTextSize = TextRenderer.MeasureText(fullText, e.CellStyle.Font);
    
                Size firstCharSize = TextRenderer.MeasureText(fullText[0].ToString(), e.CellStyle.Font);
                e.Graphics.DrawString(fullText[0].ToString(), e.CellStyle.Font, customColor, cellRect);
    
                if (!string.IsNullOrEmpty(restOfTheText))
                {
                    Size restOfTheTextSize = TextRenderer.MeasureText(restOfTheText, e.CellStyle.Font);
                    cellRect.X += (entireTextSize.Width - restOfTheTextSize.Width);
                    cellRect.Width = e.CellBounds.Width;
                    e.Graphics.DrawString(restOfTheText, e.CellStyle.Font, cellDefaultBrush, cellRect);
                }
    
                e.Handled = true;
            }
        }       
    }
