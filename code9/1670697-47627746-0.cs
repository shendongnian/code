    using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
    {
         db.ISVCSP.Where(s => s.BeneficiaryId == beneficiaryId).ForEach(item =>
         {
              item.IsDeleted = true; 
         });
         await db.SaveChangesAsync();
         scope.Complete();
    }
