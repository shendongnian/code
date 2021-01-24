    TextBox tb = new TextBox();
    tb.KeyPress  += tb_KeyPress; //add this
    this.Controls.Add(tb);
    private void tb_KeyPress(object sender, KeyPressEventArgs e)
    {
       if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) )
       {
        e.Handled = true;
       }
    }
