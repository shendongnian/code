    //Fluent
    client.Search<PurchaseOrder>(s=>s.Query(
                        q=>q.DateRange(
                            dr=>dr.Field(p=>p.VendorStatuses.First().StatusUpdateDate)
                                  .GreaterThan(fromDate)
                                  .LessThan(toDate))));
    //Object
    client.Search<PurchaseOrder>(new SearchRequest<PurchaseOrder>()
                    {
                        Query =new DateRangeQuery
                        {
                            //If you used all default mappings this might be camelCase
                            Field = "VendorStatuses.StatusUpdateDate",
                            GreaterThan = fromDate,
                            LessThan = toDate
                        }
                    });
