    if (this.DataGridView.Rows[rowIndex].Selected)
                    {
                        graphics.FillRectangle(new SolidBrush(cellStyle.SelectionBackColor), cellBounds);
                    }
                    else
                    {
                        graphics.FillRectangle(new SolidBrush(cellStyle.BackColor), cellBounds);
                    }
