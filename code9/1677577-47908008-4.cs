    protected override void Work<T>(T requestResult) where T : IWorkUnit
    {
        switch(requestResult.TypeOfWork) {
            default:
            case EWorkType.Test:
                DoTestWork(requestResult);
            break;
 
            case EWorkType.Work:
                DoWork(requestResult);
            break;
        }
    }
