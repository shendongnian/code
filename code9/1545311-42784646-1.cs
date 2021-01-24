    public List<objModel> getParameters()
        {
            var db = new SQLiteConnection(new SQLitePlatformWinRT(), pathDBLocal);
            var sList = db.Table<ModuleDB>();
            List<objModel> mList = new List<objModel>();
            
            foreach (var item in sList)
            {
                mList.Add(item.objM);                   
            }
            return mList;
        }
