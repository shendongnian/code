    List<string> filePaths = new List<string>(); // be the list to store the List
    string basePath = @"D:\TEST_SOURCE\CV\SOURCECODE\ARMY.Data\ProceduresALL\test1\abdc\ISample.cs";
    filePaths.Add(basePath); 
    
    DirectoryInfo parentInfo = Directory.GetParent(basePath);
    while (parentInfo.Parent != null)
    {
        filePaths.Add(parentInfo.FullName);
        parentInfo = Directory.GetParent(parentInfo.FullName);
    }
    
    Console.WriteLine(String.Join("\n",filePaths.OrderBy(x=>x.Length)));
