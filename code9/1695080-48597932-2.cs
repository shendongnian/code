    public void Add(int iCount)
            {
           index += iCount;                
    OperationContext.Current.GetCallbackChannel<IAction>().OnIndexChanged(index);
            }
