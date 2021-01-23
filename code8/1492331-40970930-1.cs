    public void DoSomethingSpecific()
    {
        base.DoSomethingAndRollbackThenThrow(unitOfWork => {
        _unitOfWork.Save(nameof(Function));
      });
    }
