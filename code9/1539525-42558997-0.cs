    public override DynamicMetaObject BindSetMember(SetMemberBinder binder, DynamicMetaObject value) {
        BindingRestrictions restrictions = BindingRestrictions.GetTypeRestriction(Expression, LimitType);
        System.Linq.Expressions.Expression self = System.Linq.Expressions.Expression.Convert(Expression, LimitType);
        if (binder == null) return null;
        var body = System.Linq.Expressions.Expression.Property(self, "Item", System.Linq.Expressions.Expression.Constant(binder.Name));
        var convert = System.Linq.Expressions.Expression.Convert(System.Linq.Expressions.Expression.Constant(value.Value), typeof(object));
        var lambda = System.Linq.Expressions.Expression.Assign(body, convert);
        return new DynamicMetaObject(lambda, restrictions);
    }
