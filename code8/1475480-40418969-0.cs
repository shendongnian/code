    var query = dbContext.GetAllItems().AsQueryable();
    
    //... other filters
    
    if(MusBeBetween6and8){
        query = query.Where(item => item.AcceptedTime.Hour > 6 && item.AcceptedTime.Hour < 8);
    }
    
    //... other filters
    
    return query.ToList();
