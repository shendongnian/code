                // add new checkbox to source
                var checkBoxColumn = new DataGridViewCheckBoxColumn();
                checkBoxColumn.HeaderText = "Move";
                checkBoxColumn.Name = "chkMove";
                // add new binding
                dgCheckBoxes.Columns.Insert(0, checkBoxColumn);
                
                // set values
                foreach (DataGridViewRow row in dgCheckBoxes.Rows)
                {
                    if (true)
                    {
                        row.Cells["chkMove"].Value = true;
                    }
                    else
                    {                        
                        row.Cells["chkMove"].Value = false;
                    }
                }
