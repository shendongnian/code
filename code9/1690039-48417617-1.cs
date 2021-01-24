      public class CustomDataGrid : DataGrid
      {
        public CustomDataGrid()
        {
          var converter = new BrushConverter(); 
          var background = FindResource(SystemColors.HighlightBrushKey); 
          var foreground = FindResource(SystemColors.HighlightTextBrushKey);
          this.Resources.Add(SystemColors.InactiveSelectionHighlightBr‌​ushKey, (Brush)converter.ConvertFromString(background.ToString())); 
          this.Resources.Add(SystemColors.InactiveSelectionHighlightTe‌​xtBrushKey, (Brush)converter.ConvertFromString(foreground.ToString())); 
        }
      }
