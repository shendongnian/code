    var result = myDbContext.VisitorModels
        .Where(visitorModel => !visitorModel.IsDeleted)
        .Select(visitorModel => new
        {
            // select only the properties of visitorModel you will be using:
            FullName = visitorModel.FullName,
            Address = visitorModel.Address,
            Phone = visitorModel.Phone,
            ... // other properties
            // get ArrivalTime and DepartureTime of all VisitModels that are checked in
            VisitModels = visitorModel.VisitModels
                .Where(visitModel => visitModel.IsCheckedInd)
                .Select(visitModel => new
                {   // again: select only the properties you will be using:
                    ArrivalTime = visitModel.ArrivalTime,
                    DepartureTime = visitModel.DepartureTime,
                    ... // other properties
                })
                .ToList(),
        }
    }
