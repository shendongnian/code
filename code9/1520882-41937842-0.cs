    string mergeSql = "merge into " + tableName + " as Target " +
                                      "using Ro_Consumers_Temp as Source " +
                                      "on " +
                                      "Target.ContractNo=Source.ContractNo " +
                                      "when not matched then " +
                                      "insert values (Source.Ronumber,Source.ContractNo,Source.BusinessPartner,Source.ContractAccount,Source.IBC,Source.Portion,Source.MRU,Source.Installation,Source.MeterNo,Source.LegacyNumber,Source.ConsumerNo,Source.ConsumerName,Source.Address,Source.Tariff,Source.ROAgent,Source.IBCName,Source.CD,Source.Batch,Source.JasbNumber,Source.SheetNo, Source.ContactName,Source.ContactNumber,Source.FOName,Source.[Address&LandMark],Source.NatureOfBusiness)" +
                                      "when matched " +
                                      "and Target.Batch=Source.Batch " + // <<< Move the clause here
                                      "then update set Batch = Source.Batch, JasbNumber = Source.JasbNumber"; 
