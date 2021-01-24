    var result=  (from ar in Entities.AreaMasters
    join mrs in Entities.MerchantServiceAreas on ar.AreaID equals mrs.AreaID
    join ap in Entities.ApartmentMasters on mrs.AreaID equals ap.AreaID into apl
    from ap1 in apl.DefaultIfEmpty()
    join ua in Entities.UserAddresses on ap1.ApartmentID equals ua.ApartmentID into ual
    from ua1 in ual.DefaultIfEmpty()
    where mrs.MerchantID == MerchantID
    group new { ar,mrs,ap1,ua1 }
    by new
    {
      ar.AreaID,
      ar.AreaName      
    } into uag
    select new AreaComplex
    {
      AreaID = uag.AsEnumerable().FirstOrDefault().ar.AreaID,
      AreaName = uag.AsEnumerable().FirstOrDefault().ar.AreaName,
      Pincode=  uag.AsEnumerable().Max(c=>c.ar.pincode),
      Pincode=  uag.AsEnumerable().Count(c=>c.ua1.ApartmentID),
    }).ToList();
