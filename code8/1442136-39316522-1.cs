    private void btnGo_Click(object sender, RoutedEventArgs e)
        {
         if(tbInput.Text != "0")
          {
            MessageBox.Show("Doesn't Match...");
            FocusManager.SetFocusedElement(parentElement, tbInput);
          }
        }
