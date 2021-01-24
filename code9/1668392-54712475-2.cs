    @using System;
    @using System.Text;
    
    string password = "yourpassword";
     var passwordBytes = Encoding.UTF8.GetBytes(password);
     string encodedPassword = Convert.ToBase64String(passwordBytes);
     //Debug.Write("csEncodedPassword: "+csEncodedPassword);
