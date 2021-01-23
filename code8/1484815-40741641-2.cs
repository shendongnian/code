    [DllImport("uxtheme.dll", ExactSpelling = true, CharSet = CharSet.Unicode)]
    static extern int SetWindowTheme(IntPtr hWnd, String pszSubAppName, String pszSubIdList);
    void dataGridView1_EditingControlShowing(object sender,
        DataGridViewEditingControlShowingEventArgs e)
    {
        if (e.Control is ComboBox)
            SetWindowTheme(e.Control.Handle, "", "");
    }
    void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
    {
        if (e.ColumnIndex >= 0 && e.RowIndex >= 0 &&
            this.dataGridView1.Columns[e.ColumnIndex] is DataGridViewComboBoxColumn)
        {
            var r1 = e.CellBounds;
            using (var brush = new SolidBrush(e.CellStyle.BackColor))
                e.Graphics.FillRectangle(brush, r1);
            r1.Width --;
            ControlPaint.DrawBorder3D(e.Graphics, r1, Border3DStyle.Sunken);
            e.Paint(r1, DataGridViewPaintParts.Border |
                DataGridViewPaintParts.ContentForeground);
            var d = SystemInformation.VerticalScrollBarWidth;
            var r2 = new Rectangle(r1.Right - d - 2, r1.Top + 2, d, r1.Height - 5);
            ControlPaint.DrawComboButton(e.Graphics, r2, ButtonState.Normal);
            e.Handled = true;
        }
    }
