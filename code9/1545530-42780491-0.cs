    private void G2_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            String sCellName = G2.Columns[G2.CurrentCell.ColumnIndex].Name.ToUpper();
            if (sCellName == "QUANTITY") //----change with yours
            {
                e.Control.KeyPress +=  new KeyPressEventHandler(Control_KeyPress);
            }
        }
        private void Control_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            // only allow one decimal point
            if (e.KeyChar == '.'
                && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }
