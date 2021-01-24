    public bool Update(UserBlueRayList item)
    {
    var userBRList = _db.UserBlueRayLists.Find(x => x.Id == item.Id);
    if(userBRList != null)
    {
        userBRList.Name = item.Name;
         //value assign to other entity
        _db.Entry(userBRList).State = EntityState.Modified;
        _db.SaveChanges();
        return true;
    }
    return false;
    }
