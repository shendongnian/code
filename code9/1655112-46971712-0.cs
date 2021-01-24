    public void LiteDB_ShowAll()
    {
        using (var dataBase = new LiteDatabase(dbConnectionString))
        {
            var collection = dataBase.GetCollection<Stranka>("stranka");
            collection.EnsureIndex("Ime_Priimek");
            
            lvStranke.Items.Clear();
            
            var result = collection
                .Find(Query.StartsWith("Ime_Priimek", searchName_tb.Text))
                .OrderBy(x => x["_id"].AsInt32);
            foreach (var item in result)
            {
                lvStranke.Items.Add(item);
            }               
        }         
    }
