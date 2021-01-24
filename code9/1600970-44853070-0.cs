    var tfs = TfsTeamProjectCollectionFactory.GetTeamProjectCollection(new Uri(ConfigurationManager.AppSettings["TFSUrl"]));
    tfs.EnsureAuthenticated();
    var vsStore = tfs.GetService<VersionControlServer>();
    string workingFolder = ConfigurationManager.AppSettings["LocalPathToFolder"]; // C:\TFS\SolutionFolder
    string tfsPathToFolder = ConfigurationManager.AppSettings["TFSPathToFolder"]; // $/TFS/SolutionFolder
    Workspace wsp = vsStore.GetWorkspace(workingFolder);
    if (wsp != null)
    {
         ItemSpec[] specs = { new ItemSpec(tfsPathToFolder, RecursionType.Full) };
         ExtendedItem[][] extendedItems = wsp.GetExtendedItems(specs, DeletedState.NonDeleted, ItemType.Any);
         ExtendedItem[] extendedItem = extendedItems[0];
         var itemsToDownload = extendedItem.Where(itemToDownload => itemToDownload.IsLatest == false);
         foreach (var itemToDownload in itemsToDownload)
         {
              try
              {
                   switch (itemToDownload.ItemType)
                   {
                       case ItemType.File:
                       if (itemToDownload.LocalItem != null)
                       {
                              vsStore.DownloadFile(itemToDownload.SourceServerItem, itemToDownload.LocalItem);
                       }
                       else
                       {
                              string localItemPath = itemToDownload.SourceServerItem.Replace(tfsPathToFolder,
                                        workingFolder);
                              vsStore.DownloadFile(itemToDownload.SourceServerItem, localItemPath);
                       }
                       break;
                       case ItemType.Folder:
                       string folderName = itemToDownload.SourceServerItem.Replace(tfsPathToFolder, workingFolder);
                       if ((!string.IsNullOrEmpty(folderName)) && (!Directory.Exists(folderName)))
                       {
                             Directory.CreateDirectory(folderName);
                       }
                       break;
                    }
              }
              catch (Exception e)
              {
                   File.AppendAllText(@"C:\TempLocation\GetLatestExceptions.txt", e.Message);
              }
         }
    }
