    using(RegisterForm registerForm = new RegisterForm())
    {
         DialogResult dialogResult = registerForm.ShowDialog(); 
         if(dialogResult == DialogResult.OK)
         {
            .....
         }
    }  
    // <== At this point the registerForm instance has been Disposed 
    //     and is no more usable
    ....
    private void btRegister_Click(object sender, EventArgs e)
    {
        DialogResult = !string.IsNullOrEmpty(Key) ? 
                        DialogResult.OK : DialogResult.None;
    }
    private void btCancel_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
    }
