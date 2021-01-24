    public int GetParentIdFromPath(string path)
        {
            int _parentId = 0;
            if (path != null)
            {
                var folders = GetFolderStructure();
                var splitPath = path.Split('|');
                foreach (var item in splitPath)
                {
                    _parentId = folders.Where(x => x.Name == item).SingleOrDefault().Id;
                    folders = folders.Where(x => x.Name == item).SingleOrDefault().FolderBookmarks.OfType<Folder>().ToList();
                }
                
                return _parentId;
            }
            return _parentId;
        }
