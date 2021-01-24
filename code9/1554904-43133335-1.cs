    private void txttest_GotFocus(object sender, RoutedEventArgs e)
    {
        txttest.Text = "";
        try
        {           
            btnforfocus.Focus(FocusState.Pointer);
            //txttest.IsReadOnly = true;
        }
        catch(Exception ex)
        {
        }
    }
