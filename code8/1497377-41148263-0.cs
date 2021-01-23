        private void ListViewItem_DoubleClick(object sender, RoutedEventArgs e)
        {
            System.Data.DataRowView cusObj = lvCus.SelectedItem as System.Data.DataRowView;
            if (cusObj != null)
            {
                var myobj = cusObj.Row.ItemArray;
                txtCusID.Text = myobj[0].ToString();
                txtfn.Text = myobj[1].ToString();
                txtln.Text = myobj[2].ToString();
                txtdob.Text = myobj[3].ToString();
                txtage.Text = myobj[4].ToString();
            }
        }
