    using System.Linq;
    
    ...
    
    private void doctorLogoutBtn_Click(object sender, EventArgs e)
    {
        // Free image resources (may appear to be optional, but doesn't spoil anything) 
        imgBox.Image.Dispose();
    
        // Do we have any Form1 instances?
        Form1 Login = Application
          .OpenForms
          .OfType<Form1>()
          .LastOrDefault(); // If we have several Form1's, let's take the last one
    
        // Only we haven't any Form1 instances we have to create one
        if (null == Login) 
          Login = new Form1(); 
    
        Login.Show();
    
        // Close (and Dispose) 
        this.Close();   
    }
