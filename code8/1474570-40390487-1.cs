    public void SomeMethod()
    {
        string filePath = "...";
        Task task = Task.Run<string>( (filePath) => ReadFile() );
        
        //other code
    }
    public string ReadFile(string filePath)
    {
       //read your file here, using Stream.ReadAllLine
    }
