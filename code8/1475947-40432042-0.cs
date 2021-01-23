    public bool hasID(){
      var IDs = db.users.where(x=>x.field == "test").Select(x=>x.ID).ToList();
      if(IDs.Any())
          return true;
      }
      return false;
    }
