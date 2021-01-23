    else
    {
                // first get it
                var query =
                    from ord in DataContext.Tenant_Cost_TBLs
                    where ord.lineToUpdateID = 636154619329526649
                    select ord;
                // then update it
                // Most likely you will have one record here
                foreach (Tenant_Cost_TBLs ord in query)
                {
                    ord.Cost_Amount = sDselectedRow.Cost_Amount;
                    // ... and the rest
                    // Insert any additional changes to column values.
                }
                
            }
            try
            {
                DataContext.SubmitChanges();
            }
            catch (Exception ex)
            {
                Alert.Error("Did not save", "Error", ex);
            }
