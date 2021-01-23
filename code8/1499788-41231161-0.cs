    protected void btnCopy_Click(object sender, EventArgs e)
    {
         // You would want to validate the contents of the textbox before copying.
    
         if(!string.IsNullOrEmpty(txtCopy.Text))
              Clipboard.SetText(txtCopy.Text);          
    }
