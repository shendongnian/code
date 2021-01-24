    private void DataGridCell_OnCellLostFocus(object sender, RoutedEventArgs e)
    {
        System.Windows.Controls.DataGridCell dtgCell = (System.Windows.Controls.DataGridCell)sender;
        if (dtgCell.Column.Header.ToString() == "Size")
        {
            string text = null;
            System.Windows.Controls.TextBox tbNewSize = dtgCell.Content as System.Windows.Controls.TextBox;
            if (tbNewSize != null)
            {
                text = tbNewSize.Text;
            }
            else
            {
                System.Windows.Controls.TextBlock tb = dtgCell.Content as System.Windows.Controls.TextBlock;
                if (tb != null)
                    text = tb.Text;
            }
            Int32 intNewSize = Convert.ToInt32(text);
            Int32 intCurrSize = Convert.ToInt32(strFieldInfoOrig[dtGrid.Items.IndexOf(dtGrid.CurrentItem), 1]);
            if (intNewSize < intCurrSize)
            {
                string strMsg;
                strMsg = "New size, " + intNewSize.ToString() + " is smaller then the original size, " + intCurrSize.ToString();
                strMsg += Environment.NewLine;
                strMsg += "Due to potential data loss, this is not allowed.";
                System.Windows.MessageBox.Show(strMsg);
                //dtgCell.Content = intCurrSize.ToString();
                dtgCell.Focus();
            }
        }
    }
