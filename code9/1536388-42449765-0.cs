    private void Grid1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
    { 
      ComboBox cb = e.Control as ComboBox;
                    if (cb!=null)
                    { cb.SelectionChangeCommitted -= new EventHandler(cb_SelectedIndexChanged);
    
                        // now attach the event handler
                        cb.SelectionChangeCommitted += new EventHandler(cb_SelectedIndexChanged);
                    }
    }}
