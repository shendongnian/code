    context.Configuration.LazyLoadingEnabled = false;//to remove lazy loading for this query only
    
    data = context.TABLE1.Where(x => startDate <= 
    DbFunctions.TruncateTime(x.LAST_UPDATED_DATE) && endDate >= 
    DbFunctions.TruncateTime(x.LAST_UPDATED_DATE)).Include(x => x.TABLE2);   
       
    var result = data.Where(x => x.TABLE2.MAP_TYPE_CODE.Trim().ToUpper() == reportCode.Trim().ToString())
    .select new
       {
          //your projection
       
       }).AsNoTracking().ToList()
  
      
