    IEnumerable<CarOnline> carOnlineData = (IEnumerable<CarOnline>)vehrep.GetCarOnlineDetail(maintainStopFactoryOrderNo.VehicleDetail).Result;
    
    StopFYON stopFyon;
    
    if (carOnlineData.Any())
        stopFyon = vehtran.CreateStopFactoryOrderNo(carOnlineData, maintainStopFactoryOrderNo, lastUpdatedBy);
    else
        stopFyon = vehtran.CreateStopFactoryOrderNo(null, maintainStopFactoryOrderNo, lastUpdatedBy);
