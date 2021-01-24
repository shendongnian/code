     private FolderId GetFolder()
        {
          FolderId  _gloableFolderId = null;
            try
            {
                //Find folders
                FolderView view = new FolderView(20);
                view.PropertySet = new PropertySet(BasePropertySet.IdOnly);
                view.PropertySet.Add(FolderSchema.DisplayName);
                view.Traversal = FolderTraversal.Deep;
                FindFoldersResults findFoldersResults = _globalService.FindFolders(WellKnownFolderName.Calendar, view);
                foreach (var folder in findFoldersResults)
                {
                    if (folder is Folder)
                    {
                        if (folder.DisplayName.ToUpper() == "TEST") 
                        {
                            _gloableFolderId = folder.Id;
                            return _gloableFolderId;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
              // Log exception or return main calender
            }
            return _gloableFolderId;
        }
