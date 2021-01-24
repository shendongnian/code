    private IEnumerable<MProduct> Order(List<MProduct> items, bool isDescending, Action<IApplyer<MProduct>> orderByLambda)
    {
        IApplyer<MProduct> applyer;
        if (isDescending)
        {
            applyer = new OrderByApplyer<MProduct>(items);
        }
        else
        {
            applyer = new OrderDescendingByApplyer<MProduct>(items);
        }
        orderByLambda(applyer);
        return applyer.Result;
    }
    // Usage
    Order(items, true, a => a.Apply(o => o.Name));
    Order(items, true, a => a.Apply(o => o.Age));
    Dictionary<string, Action<IApplyer<MProduct>>> columns = new Dictionary<string, Action<IApplyer<MProduct>>>
    {
        ["Name"] = a => a.Apply(o => o.Name),
        ["Age"] = a => a.Apply(o => o.Age),
    };
    Order(items, true, columns["Age"]);
    //Implementation
    interface IApplyer<TTarget>
    {
        void Apply<TColumn>(Func<TTarget, TColumn> orderBy);
        IOrderedEnumerable<TTarget> Result { get; set; }
    }
    class OrderByApplyer<TTarget> : IApplyer<TTarget>
    {
        public OrderByApplyer(IEnumerable<TTarget> target)
        {
            this.Target = target;
        }
        public IEnumerable<TTarget> Target { get; }
        public IOrderedEnumerable<TTarget> Result { get; set; }
        public void Apply<TColumn>(Func<TTarget, TColumn> orderBy)
        {
            this.Result = this.Target.OrderBy(orderBy);
        }
    }
    class OrderDescendingByApplyer<TTarget> : IApplyer<TTarget>
    {
        public OrderDescendingByApplyer(IEnumerable<TTarget> target)
        {
            this.Target = target;
        }
        public IEnumerable<TTarget> Target { get; }
        public IOrderedEnumerable<TTarget> Result { get; set; }
        public void Apply<TColumn>(Func<TTarget, TColumn> orderBy)
        {
            this.Result = this.Target.OrderByDescending(orderBy);
        }
    }
    class ThenByApplyer<TTarget> : IApplyer<TTarget>
    {
        public ThenByApplyer(IOrderedEnumerable<TTarget> target)
        {
            this.Target = target;
        }
        public IOrderedEnumerable<TTarget> Target { get; }
        public IOrderedEnumerable<TTarget> Result { get; set; }
        public void Apply<TColumn>(Func<TTarget, TColumn> orderBy)
        {
            this.Result = this.Target.ThenBy(orderBy);
        }
    }
    class ThenByDescendingByApplyer<TTarget> : IApplyer<TTarget>
    {
        public ThenByDescendingByApplyer(IOrderedEnumerable<TTarget> target)
        {
            this.Target = target;
        }
        public IOrderedEnumerable<TTarget> Target { get; }
        public IOrderedEnumerable<TTarget> Result { get; set; }
        public void Apply<TColumn>(Func<TTarget, TColumn> orderBy)
        {
            this.Result = this.Target.ThenByDescending(orderBy);
        }
    }
