    private void TriggerKeyboard(object sender, EventArgs e) {
         try {
            Osklib.OnScreenKeyboard.Show();
         } 
        catch(Exception ex) {
           MessageBox.Show(ex.Message);
        }
     }
