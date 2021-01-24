    public TradeProcessor(IServiceProvider provider)
    {
       // save the provider in a field
    }
    public void ThisNeedsADynamicallyCreatedContainerObject()
    {
        if(condition)
        {
            var instance = this.provider.GetService<ICompoundTrade>();
        }
        else
        {
            var instance = this.provider.GetService<ISingleTrade>();
        }
    }
