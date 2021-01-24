    using System;
    using System.Windows.Forms;
    using System.Reflection;
    public static class DataGridViewColumnExtensions
    {
        public static DataGridViewCellStyle GetFormattedStyle(this DataGridViewCell cell) {
            var dgv = cell.DataGridView;
            if (dgv == null)
                return cell.InheritedStyle;
            var e = new DataGridViewCellFormattingEventArgs(cell.RowIndex, cell.ColumnIndex,
                cell.Value, cell.FormattedValueType, cell.InheritedStyle);
            var m = dgv.GetType().GetMethod("OnCellFormatting",
                BindingFlags.Instance | BindingFlags.NonPublic,
                null,
                new Type[] { typeof(DataGridViewCellFormattingEventArgs) },
                null);
            m.Invoke(dgv, new object[] { e });
            return e.CellStyle;
        }
    }
