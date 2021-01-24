    dbEntity.LoanApplicationQualificationTypes = entity.LoanApplicationQualificationTypes
    	.Select(e => new LoanApplicationQualificationTypes
    	{
    		LoanApplicationId = e.LoanApplicationId,
    		QualificationTypeId = e.QualificationTypeId,
    		ModifiedDate = DateTime.UtcNow,
    		ModifiedBy = UserOrProcessName,
    	})
    	.ToList();
