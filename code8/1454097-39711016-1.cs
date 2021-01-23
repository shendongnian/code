    if (!LoginUser("Fooooo", "Bar"))
    {
        MessageBox.Show(e.Message);
    }
    private static bool LoginUser(string pUsername, string pPassword)
    {
        if (pUsername != "Foo" || pPassword != "Bar")
            return false;
            
        GrantAccess(pUsername);            
        return true;
    } 
