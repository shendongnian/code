        void ClassForm_Load(object sender, EventArgs e)
        {
            datagridview1.CellMouseDown -= MouseClick;
            datagridview1.CellMouseDown += MouseClick;
        }
        void MouseClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            if(dgv == null) return;
            DataGridViewButtonCell b = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex] as DataGridViewButtonCell;
            if (b != null)
            {
                MyPopupTreeWindow myPopupTreeWindow = new MyPopupTreeWindow(optional information from button);
                myPopupTreeWindow.ShowDialog();
                string userSelectedString = myPopupTreeWindow.userSelectedString;
                datagridview1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = userSelectedString;
            }
        }
