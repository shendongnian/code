            try
            {
                // Display the pattern number in column 0
                this.dataGridView_patterns.Rows[currentRow].Cells["patternNumber"].Value = currentRow + 1;
                // Move the current cell focus to column 1 (Terminator pattern) on current row
                if (e.ColumnIndex == 0)
                {
                    this.BeginInvoke(new MethodInvoker(() =>
                    {
                        moveCellTo(dataGridView_patterns, e.RowIndex, "patternsTer");
                    }));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, errCaption, button, icon);
            }
        }
        private void moveCellTo(DataGridView dgCurrent, int rowIndex, string columnName)
        {
            dgCurrent.CurrentCell = dgCurrent.Rows[rowIndex].Cells[columnName];
        }
