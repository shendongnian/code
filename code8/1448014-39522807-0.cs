    class ItemProvider
    {
        public List<Item> GetItems(string path, SearchOption searchOption)
        {
            var items = new List<Item>();
            var dirInfo = new DirectoryInfo(path);
            foreach (var directory in dirInfo.GetDirectories("*.*", SearchOption.TopDirectoryOnly))
            {
                var item = new DirectoryItem
                {
                    Name = directory.Name,
                    Path = directory.FullName,
                    Items = GetSubItems(directory.FullName, SearchOption.AllDirectories)
                };
                items.Add(item);
            }
     
            return items;
        }
        public List<Item> GetSubItems(string path, SearchOption searchOption)
        {
            var items = new List<Item>();
            var dirInfo = new DirectoryInfo(path);
 
            foreach (var subdirectory in dirInfo.GetDirectories("*.*", SearchOption.AllDirectories))
            {
                var item = new SubDirectoryItem()
                {
                    Name = subdirectory.Name,
                    Path = subdirectory.FullName,
                    Items = GetSubItems(subdirectory.FullName, SearchOption.AllDirectories)
                };
                items.Add(item);
            }
            foreach (var file in dirInfo.GetFiles())
            {
                var item = new FileItem
                {
                    Name = file.Name,
                    Path = file.FullName
                };
                items.Add(item);
            }
            return items;
        }
    }
