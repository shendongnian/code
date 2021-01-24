    try
    {
        stopInfo stop = (from s in rDb.DistributionStopInformations
                        where s.UniqueIdNo == item.UniqueIdNo
                        select new stopInfo // here you instantiate your class
                        {
                            s.BranchId,
                            s.RouteCode,
                            s.StopName,
                            s.StopAddress,
                            s.StopCity,
                            s.StopState,
                            s.StopZipPostalCode,
                        }).First();
        }
    catch (Exception)
    {
        // exception-handling, e.g. logging
        throw;
    }
