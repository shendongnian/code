    public Dictionary<int, data>_WeapList;
    
    [...]
    //reading the SQL Table + parse it into a new List-entry
    while (rdr.Read())
    {
        data itm = new data();
        itm.Name = rdr["Name"].ToString();
        itm.ID = int.Parse (rdr["ID"].ToString());
        itm.dmg = int.Parse (rdr["dmg"].ToString());
        itm.range = int.Parse (rdr["range"].ToString());
        itm.magazin = int.Parse (rdr["magazin"].ToString());
        itm.startammo = int.Parse (rdr["startammo"].ToString());
        itm.tbtwb = float.Parse(rdr["tbtwb"].ToString());
        itm.rltimer = float.Parse(rdr["rltimer"].ToString());
        _WeapList.Add(itm.ID, itm);//probable change
    }
