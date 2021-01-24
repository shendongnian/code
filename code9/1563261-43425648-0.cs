    private void txtPhoneNumber_KeyPress(object sender, KeyPressEventArgs e) {
      if (!Char.IsDigit(e.KeyChar) && (e.KeyChar != (char)(Keys.Back))) { 
        e.Handled = true;
      }
      else {
        // is a digit or backspace - ignore digits if length is alreay 10 - allow backspace
        if (Char.IsDigit(e.KeyChar)) {
          if (txtPhoneNumber.Text.Length > 9) {
            e.Handled = true;
          }
        }
      }
    }
