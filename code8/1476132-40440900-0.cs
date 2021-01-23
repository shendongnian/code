    public string getCode(string login, string password) 
    {
        IntPtr retval = GetCode(login, password);
        string result = Marshal.PtrToStringAnsi(retval);
        // how do we deallocate retval
        return result;
    }
