    public List<PMTestType> GetTestSP()
    {
    	using (var uow = UnitOfWorkManager.Begin())
    	{
            var ret = _storedProcRepository.ExecuteSP("exec pme_TestProcedure", new SqlParameter("inputString", "abcde"));
    		uow.Complete();
            return ret.ToList();
    	}
    }
