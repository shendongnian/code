    var exchangeDatas = from p in db.ExchangeDatas
                        where p.ExchangeDataSeqid == entity.ExchangeDataSeqid
                        select p;
    return (from p in exchangeDatas.AsEnumerable() 
                      select new ProcessAccountViewModel()
                      {
                          ExchangeCode = p.ExchangeCode,
                          UtilityCompany = p.UtilityCompanySeqid,
                          InvoiceBillingGroup = p.AccountBillingGroupSeqid,
                          AccountNumber = p.CurrentAccountNumber,
                          TurnOnDate = DateTime.ParseExact(p.AccountEffectiveTurnOn, "yyyyMMdd", CultureInfo.InvariantCulture),
                          SalesType = p.SalesType,
                          BillingCycle = p.BillingCycle,
                          TripNumber = p.TripNumber,
                          IsTimeOfDay = p.TODAccount == "Y" ? true : false,
                          IsExcessDistribution = p.ExcessDistributionAccount == "Y" ? true : false,
                          EnergyDeliverType = p.EnergyDeliveryType ?? 0,
                          Name = p.AccountName,
                          Address = p.AccountAddress,
                          Borough = p.Borough,
                          Facility = p.FacilitySeqid == null ? "" : p.FacilitySeqid.Value.ToString(),
                          Agency = p.AgencySeqid == null ? "" : p.AgencySeqid.Value.ToString(),
                          ServiceClass = p.DeliveryServiceClass,
                         AuthenticatedUserID = p.authenticatedUserID ?? 0,
                         ApprovedForCreation = p.ApprovedForCreation,
                         TransactionEffectiveDate = DateTime.ParseExact(p.TransactionEffectiveDate, "yyyyMMdd", CultureInfo.InvariantCulture),
                         ActivityTime = DateTime.ParseExact(p.ActivityTime, "yyyyMMdd", CultureInfo.InvariantCulture),
                         DateAdded = p.DateAdded,
                         LastUpdate = p.LastUpdate,
                         Exclude = p.Exclude,
                         IsProcessed = p.IsProcessed,
                         BillingPeriod = p.BillingPeriod
                     }).FirstOrDefault();
