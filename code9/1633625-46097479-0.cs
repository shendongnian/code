    public IUnitOfWorkManager _unitOfWorkManager {get; set;}
    [UnitOfWork(IsDisabled = true)]
    public async Task<WorkflowStepDto> GetCurrentWorkflowStep(...)
    {
        using (var unitOfWork = _unitOfWorkManager.Begin())
        {
            //your code....
        }
    }
