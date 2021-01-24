    //function
    public static void NumberOnly(object sender, KeyPressEventArgs e)
    {
         e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
    }
    //to call used this
    NumberOnly("your textbox");
     
    
