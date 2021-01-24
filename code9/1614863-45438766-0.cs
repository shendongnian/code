    foreach (string strInputToDelete in dataSetsToDelete)
    {
       Console.WriteLine("Listing files and directories.");
       var itemList = _adlsFileSystemClient.FileSystem.ListFileStatus(_adlsAccountName, strInputToDelete).FileStatuses.FileStatus.ToList();
       var fileMenuItems = itemList.Select(a => String.Format("{0,15} {1}", a.Type, a.PathSuffix));
       Console.WriteLine(String.Join("\r\n", fileMenuItems));
       Console.WriteLine("Files and directories listed.");
        
       for (int i = 0; i < itemList.Count; i++)
       {
            Console.WriteLine("Deleting files...");
            var fileDeleteResult =_adlsFileSystemClient.FileSystem.Delete(_adlsAccountName, strInputToDelete + itemList[i].PathSuffix);
            Console.WriteLine("Deletion result: " + fileDeleteResult.OperationResult.ToString());
            Console.WriteLine("Files deleted");
       }
    }
