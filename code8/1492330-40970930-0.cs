    public void DoSomethingAndRollbackThenThrow(Action<IUnitOfWork> action)
    {
       try
      {
       ...
        action(_unitOfWork);
      }
      catch
      {
       if (rollbackTo != null)
       {
          _unitOfWork.RollbackToSave(rollbackTo);
       }
       else
       {
           _unitOfWork.Rollback();
       }
       throw;
     }
    }
