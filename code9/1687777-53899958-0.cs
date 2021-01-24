    public IList<string> RootDirectory()
            {
                var Pathlist = new List<string>(); 
                try
                {
                    var temp = new List<string>();
                    Pathlist.Add(Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryDocuments).AbsolutePath);
                    Pathlist.Add(Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryDownloads).AbsolutePath);
                    Pathlist.Add(Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryMusic).AbsolutePath);
                    foreach(var path in Pathlist)
                    {
                        if (Directory.Exists(path))
                        {
                            temp.AddRange(Directory.EnumerateDirectories(path).ToList());
                        }
                    }
                    Pathlist.AddRange(temp);
                    return Pathlist;
                }
                catch (Exception e)
                {
                    throw;
                }      
            }
    
    public IList<string> GetFiles()
            {
                var files = new List<string>();
                foreach(var dir in RootDirectory())
                {
                    if (Directory.Exists(dir))
                    {
                        var file = Directory.EnumerateFiles(dir).ToList<string>();
                        file.ForEach(f => { if (f.EndsWith("mp3")) files.Add(f); });
                    }  
                }
                return files;
            }
