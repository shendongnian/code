                    var rowCellStyle = new DataGridViewCellStyle(theMessagesGrid.DefaultCellStyle)
                    {
                        BackColor = string.IsNullOrEmpty(conditions) 
                               ? theGrid.DefaultCellStyle.BackColor 
                               : theColor,
                        SelectionForeColor = Color.WhiteSmoke,
                        SelectionBackColor = theGrid.DefaultCellStyle.SelectionBackColor,
                    };
                var theRow = new DataGridViewRow 
                    { 
                       Height = theGrid.RowTemplate.Height, 
                       DefaultCellStyle = rowCellStyle, 
                       Tag = Event.GroupName 
                    };
                
                theRow.CreateCells(theGrid);
                var cellData = new object[theRow.Cells.Count];
                
                // fill out cell data
                cellData[0] = ...;
                cellData[1] = ...
                theRow.SetValues(cellData);
                
                // add row to grid
                try
                {
                    theGrid.Rows.Add(theRow);
                    if (currentMsg == Event.Pkey) theGrid.Rows[theGrid.Rows.Count - 1].Selected = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, @"Error Building Grid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    throw;
                }
