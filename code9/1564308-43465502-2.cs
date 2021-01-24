    private void txt_pay2_TextChanged(object sender, EventArgs e) {
      // Contract:
      if ((String.IsNullOrEmpty(txt_pay2.Text)) {
        MessageBox.Show("Enter A Amount Please !!");
        // My suggestion (Win Forms): when asking user to enter anything (A Amount)
        // set keyboard focus for he/she start entering the value 
        if (txt_pay2.CanFocus)
          txt_pay2.Focus();
    
        return;
      } 
    
      // Try to get values:
      int Pay_Dues;
      int Pay;
    
      if (!int.TryParse(pay_dues.Text, out Pay_Dues))
        return; // Bad pay_dues.Text format
      else if (!int.TryParse(txt_pay2.Text, out Pay))
        return; // Bad txt_pay2.Text format 
      // We've met contract's requirements and we've got Pay_Dues, Pay values 
    
      // We don't want a cascade of txt_pay2.TextChanged events:
      // txt_pay2.Text = ... triggers txt_pay2_TextChanged 
      // which in turn calls txt_pay2.Text =  ...
      txt_pay2.TextChanged -= txt_pay2_TextChanged;
    
      try {
        txt_pay2.Text = (Pay_Dues - Pay).ToString(); 
      }
      finally {
        txt_pay2.TextChanged += txt_pay2_TextChanged;
      }
    }
