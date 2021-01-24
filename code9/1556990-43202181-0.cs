    private void txt2_PreviewKeyDown(object sender, KeyEventArgs e)
    {
       if (e.Key == Key.Return)
            {
                try
                {
                   CalculateSomethingFromOtherTextBoxes();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
    }
