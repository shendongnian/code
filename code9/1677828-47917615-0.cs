     private void gridView_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                             
        {
            if (e.PropertyName == "code" && rdbCode.IsChecked == true)
            {
                e.Column.Header = "Acct Code";
            }
            else if (e.PropertyName == "code" && rdbPart.IsChecked == true)
            {
                e.Column.MaxWidth = 0;
            }
            if (e.PropertyName == "um")
            {
                e.Column.MaxWidth = 0;
            }
            if (e.PropertyName == "part" && rdbPart.IsChecked == true)
            {
                e.Column.Header = "Part ID";
            }
            else if (e.PropertyName == "part" && rdbCode.IsChecked == true)
            {
                e.Column.MaxWidth = 0;
            }
            if (e.PropertyName == "check")
            {
                CheckBox chk = new CheckBox();
                e.Column.Header = chk;
                chk.Content = "Update All";
                chk.Checked += chk_Checked;
                chk.Unchecked += chk_Unchecked;
            }
        }
