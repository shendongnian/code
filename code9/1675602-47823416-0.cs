       List<string> patterns = new List<string> { "apple*", "pear*", "orange*" };
       DirectoryInfo prefetch = new DirectoryInfo("c:\\Windows\\Prefetch");         
      
       foreach (var pattern in patterns) {
           FileInfo[] files = prefetch.GetFiles(pattern);
           var lastAccessed = files.OrderByDescending(x => x.LastAccessTime).FirstOrDefault();
           if (lastAccessed != null) {
               var minutes = DateTime.Now.Subtract(lastAccessed.LastAccessTime).TotalMinutes;
           }
       }
