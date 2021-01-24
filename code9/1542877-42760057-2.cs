    public bool Update(ILoanApplication entity)
    {
        using (var db = new MainContext())
        {
            var dbEntity = db.LoanApplication
                .Include(e => e.LoanApplicationQualificationTypes)
                .FirstOrDefault(e => e.Id == entity.Id);
            if (dbEntity == null) return false;
            db.Entry(dbEntity).CurrentValues.SetValues(entity);
            dbEntity.ModifiedDate = DateTime.UtcNow;
            dbEntity.ModifiedBy = UserOrProcessName;
            dbEntity.LoanApplicationQualificationTypes = entity.LoanApplicationQualificationTypes
    	        .Select(e => new LoanApplicationQualificationTypes
    	        {
                    LoanApplicationId = e.LoanApplicationId,
                    QualificationTypeId = e.QualificationTypeId,
                    ModifiedDate = DateTime.UtcNow,
                    ModifiedBy = UserOrProcessName,
    	        })
    	        .ToList();
            db.SaveChanges();
            return true;
        }
    }
