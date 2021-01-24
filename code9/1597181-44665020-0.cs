    public class yourClassName {
       static object _lock = new object();
       static IDictionary<string, string> loadedValues = new Dictionary<string, string>();
       private string BuildString(int folderID) {
            if (!loadedValues.ContainsKey(folderID)) // if we dont have the value 
                using (SA sa = new SA())
                using (IRWS irws = new IRWS(sa.Ticket))
                    lock(this)
                        if (loadedValues.ContainsKey(folderID)) // lets check again (maybe in btween the locks other threads did the job)
                            lock(_lock)
                                return loadedValues[folderID];
                        else // it looks like we dont have it (now it is populated)
                            loadedValues[folderID] = irws.getFolderPathfromFolderID(folderID);
            return loadedValues[folderID]
        }
        [HttpGet]
        public string _SearchGetFolderPath(int folderID)
        {
            return BuildString(folderID);
        }
    }
