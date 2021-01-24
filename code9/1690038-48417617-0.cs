      public class CustomDataGrid : DataGrid
      {
        public CustomDataGrid()
        {
          this.Resources.Add(
            SystemColors.InactiveSelectionHighlightBrushKey,
            SystemColors.HighlightColor);
          this.Resources.Add(
            InactiveSelectionHighlightTextBrushKey,
            SystemColors.HighlightTextColor);
        }
      }
