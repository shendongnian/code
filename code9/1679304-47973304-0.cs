        private void cellAssignments_dgv_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is ComboBox)
            {
                ComboBox cb = (ComboBox)e.Control;
                if (cb != null)
                {
                    // Show the DropDown of the combo & set its event
                    cb.DropDownStyle = ComboBoxStyle.DropDownList;
                    cb.SelectionChangeCommitted -= cb_SelectionChangeCommitted;
                    cb.SelectionChangeCommitted += cb_SelectionChangeCommitted;
                }
            }
        }
        void cb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            if (cb != null)
            {
                Console.WriteLine("Selected Combo = " + cb.SelectedText + " Value = " + cb.SelectedValue);
                // Notify the cell is dirty
                cellAssignments_dgv.NotifyCurrentCellDirty(true);
                // Force to End Edit the Cell
                cellAssignments_dgv.EndEdit();
            }
        }
