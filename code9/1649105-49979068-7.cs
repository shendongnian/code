    //Wrong code
    var dataObject = await dbContext.Table.where(x=>x.UserId == model.UserId).TolistAsync();
    foreach(var item in dataObject)
    { 
       var x=new DataObject()
       {
          x=item.Id
       };
       dbContext.Table.Remove(x);
    }
