    public void SomeMethod()
    {
        string filePath = "...";
        Task<string[]> task = Task.Run<string[]>( () => ReadFile(filePath) );
        //if you want to not block the UI with Task.Wait() for the result
        // and you want to perform some other operations with the already read file
        task.ContinueWith( (x) => {
            string[] result = x.Result; //result of readed file
          
        });
        
        //other code not related with the file which you want to read !
    }
    public string[] ReadFile(string filePath)
    {
       List<String> lines = new List<String>();
       string line = "";
        using (StreamReader sr = new StreamReader(filePath))
        {
            while ((line = sr.ReadLine()) != null)
                lines.Add(line);
        }
       return lines.ToArray();
    }
