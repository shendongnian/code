    public virtual void StartCellEdit(OLVListItem item, int subItemIndex) {
                OLVColumn column = this.GetColumn(subItemIndex);
                Control c = this.GetCellEditor(item, subItemIndex);
                Rectangle cellBounds = this.CalculateCellBounds(item, subItemIndex);
                c.Bounds = this.CalculateCellEditorBounds(item, subItemIndex, c.PreferredSize);
    
                // Try to align the control as the column is aligned. Not all controls support this property
                Munger.PutProperty(c, "TextAlign", column.TextAlign);
    
                // Give the control the value from the model
                this.SetControlValue(c, column.GetValue(item.RowObject), column.GetStringValue(item.RowObject));
    
                // Give the outside world the chance to munge with the process
                this.CellEditEventArgs = new CellEditEventArgs(column, c, cellBounds, item, subItemIndex);
                this.OnCellEditStarting(this.CellEditEventArgs);
                if (this.CellEditEventArgs.Cancel)
                    return;
    
                // The event handler may have completely changed the control, so we need to remember it
                this.cellEditor = this.CellEditEventArgs.Control;
                
                this.Invalidate();
                this.Controls.Add(this.cellEditor);
                this.ConfigureControl();
                this.PauseAnimations(true);
            }
