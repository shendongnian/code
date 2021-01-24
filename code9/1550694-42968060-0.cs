    System.Dynamic.DynamicMetaObject System.Dynamic.IDynamicMetaObjectProvider.GetMetaObject(
        System.Linq.Expressions.Expression parameter)
    {
        return new DapperRowMetaObject(parameter, 
            System.Dynamic.BindingRestrictions.Empty, this);
    }
