    const string _listofStuffFile = "allMyStuff.txt";
    public static async Task<bool> SaveMyListData(List<string> saveData)
        {
            try
            {
                var savedStuffFile = await ApplicationData.Current.RoamingFolder.CreateFileAsync(_listofStuffFile, CreationCollisionOption.ReplaceExisting);
                using (Stream ws = await savedStuffFile.OpenStreamForWriteAsync())
                {
                    var ss = new DataContractSerializer(typeof(List<string>));
                    ss.WriteObject(ws, saveData);
                }
                return true;
            }
            catch { }
            return false;
        }
    public static async Task<List<string>> GetMyListData()
        {
            try
            {
                var rs = await ApplicationData.Current.RoamingFolder.OpenStreamForReadAsync(_listofStuffFile);
                if (rs == null)
                    return new List<string>();
                var ss = new DataContractSerializer(typeof(List<string>));
                var sr = (List<string>)ss.ReadObject(rs);
                return sr;
            }
            catch { }
            return new List<string>();
        }
