    @model List<TransportationProvidersDemo.Models.Provider>
        @{
             var providersFound = ViewBag.ListOfProviders != null ?
                                      ViewBag.ListOfProviders as List<Providers> : 
                                      null; 
        }
    <ommited form here>
        @if (providersFound!= null)
        {
            foreach (var item in Model)
            {
                <div>
                    <h3>@item.AgencyName</h3>
                </div>
            }
        }
    </div>
