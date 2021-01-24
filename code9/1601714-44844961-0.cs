    (from am in Entities.AreaMasters.GetQueryable()
     join msa in Entities.MerchantServiceAreas.GetQueryable()
    .Where(a=> a.MerchantID == MerchantID) on am.AreaID equals msa.AreaID
    join apm in Entities.ApartmentMasters.GetQueryable() on am.AreaID equals 
    apm.AreaID into apmjoin from apmlj into apmjoin.DefaultIfEmpty()
    join ua in Entities.UserAddresses.GetQueryable() on apmlj.ApartmentID equals 
    ua.ApartmentID into uajoin from ualj in uajoin.DefaultIfEmpty()
    select new { newAreaID = am.AreaID,newAreaName =  am.AreaName, newPincode= 
    am.Pincode})
    .GroupBy(a=> new {AreaID = a.newAreaID,AreaName = a.newAreaName,Pincode= 
    a.newPincode})
    .Select(x=> new AreaComplex { AreaID = x.FirstOrDefault().AreaID,
    AreaName = x.FirstOrDefault().AreaName,Pincode = x.Sum(a=>a.Pincode) }).toList();
     
