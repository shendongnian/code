    public void work()
    {
        ExpGenMethod((a) => {/*do something that matters*/});
    }
    public void ExpGenMethod(Action<int> inputDel, int parameterToUse)
    {
        inputDel(parameterToUse);
    }
