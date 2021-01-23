    public void SomeMethod()
    {
        Task task = Task.Run( () => ReadFile() );
        
        //other code
    }
    public void ReadFile()
    {
       //read your file here.
    }
