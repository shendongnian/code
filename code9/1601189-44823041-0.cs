            private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
            {
                if (e.ColumnIndex == 0 && e.RowIndex > -1)
                {
                    e.AdvancedBorderStyle.Left = DataGridViewAdvancedCellBorderStyle.None;
                    e.AdvancedBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.None;
                    e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;
                }
            }
