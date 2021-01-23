    /// <summary>
    ///  Getting and setting the column widths of a DataGrid is not easy at all.
    ///  This helper class handles it, including saving and restoring from a string.
    /// </summary>
    static class DataGridColumnWidthExtensions
    {
        /// Get the current table style.
        public static DataGridTableStyle GetCurrentTableStyle(this DataGrid grid)
        {
            // DataGrid holds the current grid table style into a private field called myGridTable.
            // The field points to the "default" table style even if TableStyles is empty. The 
            // default table style is also private/internal.
            // See https://stackoverflow.com/a/39832554/492336 and 
            // https://referencesource.microsoft.com/#System.Windows.Forms/winforms/Managed/System/WinForms/DataGrid.cs,211.
            FieldInfo[] fields = grid.GetType().GetFields(
                         BindingFlags.NonPublic |
                         BindingFlags.Instance);
            return (DataGridTableStyle)fields.First(item => item.Name == "myGridTable").GetValue(grid);
        }
    }
