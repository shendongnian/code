    string dbNameTrimmed = dbname.TrimStart("Car Name: ".ToCharArray());
    if(DBIndexList[i].DatabaseName.Equals(dbNameTrimmed, StringComparison.OrdinalIgnoreCase))
    {
       DBIndexList.Remove(DBIndexList[i]);
    }
