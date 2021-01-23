    var newData = Database
               .GetBillsRecordsForTenant(Database.DataContext, SelectedTenant.Code)
               .Select(item => new Tenant_Bills_TBL{
                    ID = DateTime.UtcNow.Ticks;
                    Tenant_Code = SelectedTenant.Code;
                    Year_Data = DateFilter.Year;
                    Month_Data = DateFilter.Month;
                    Tenant_Bill = item.Tenant_Bill;
                    Bill_Amount = item.Bill_Amount;
                    Bill_Quantity = item.Bill_Quantity;                                          
                    })
               .ToList();
        Database.DataContext.Tenant_Bills_TBLs.InsertAllOnSubmit(addNewData);
