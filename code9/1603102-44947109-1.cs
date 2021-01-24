    using(DalSession dalSession = new DalSession())
    {
        UnitOfWork unitOfWork = dalSession.UnitOfWork;
        unitOfWork.Begin();
        try
        {
            //Your database code here
            repository1.DoThis();
            repository2.DoThat();
            
            unitOfWork.Commit();
        }
        catch
        {
            unitOfWork.Rollback();
            throw;
        }
    }
