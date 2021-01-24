    public static bool AddNewAccount(out int id, out string password)
    {
        id = 0;
        password = "";
        AddNewAccountForm f = new AddNewAccountForm();
        bool result = (f.ShowModal() == ModalResult.OK);
        
        if(result)
        {
           id = f.GetId();
           password = f.GetPassword();
        }
        f.Dispose();
        return result;
    }
