    Try:
    private void listViewItem_MouseDown (object sender, MouseButtonEventArgs e)
                {
                    Application.Current.Dispatcher.BeginInvoke (new Action (() =>
                    {
                        MessageBox.Show ("ROW CLICKED");
                    }));
                   
                }
