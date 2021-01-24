    public string Username {
        //...
    }
    
    public string Password {
        //...
    }
    
    public bool CanLogin() {
        return !String.IsNullOrEmpty(Username) && !String.IsNullOrEmpty(Password);
    }
    
    public void Login() {
        MessageBox.show(Password + " " + Username)
    }
