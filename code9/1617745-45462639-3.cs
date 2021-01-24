    try
    {
        stopInfo stop = (from s in rDb.DistributionStopInformations
                        where s.UniqueIdNo == item.UniqueIdNo
                        select new stopInfo // here you instantiate your class
                        {
                            BranchId = s.BranchId,
                            RouteCode = s.RouteCode,
                            StopName = s.StopName,
                            StopAddress = s.StopAddress,
                            StopCity = s.StopCity,
                            StopState = s.StopState,
                            StopZipPostalCode = s.StopZipPostalCode,
                        }).First();
        }
    catch (Exception)
    {
        // exception-handling, e.g. logging
        throw;
    }
