    public class Form2:Form
    {
         private bool _isValidated = false;
         public Form2()
         {
             InitializeComponent();
             // Add here the conditions to check if you don't want to 
             // run the login process...
             // if(loginNotRequired) 
             //    _isValidated = true;
             // else 
             using(Form1 fLogin = new Form1())
             {
                 // This blocks until the user clicks cancel or ok buttons
                 DialogResult dr = fLogin.ShowDialog();
                 if(dr == DialogResult.OK)
                    _isValidated  = true;
             }
         }
