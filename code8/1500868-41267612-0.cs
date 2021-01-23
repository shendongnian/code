    public sealed class ForwardingMetaObject : DynamicMetaObject
    {
        private readonly DynamicMetaObject _metaForwardee;
        public ForwardingMetaObject(
            Expression expression,
            BindingRestrictions restrictions,
            object forwarder,
            IDynamicMetaObjectProvider forwardee,
            Func<Expression, Expression> forwardeeGetter
            ) : base(expression, restrictions, forwarder)
        {
            // We'll use forwardee's meta-object to bind dynamic operations.
            _metaForwardee = forwardee.GetMetaObject(
                forwardeeGetter(
                    Expression.Convert(expression, forwarder.GetType())   // [1]
                )
            );
        }
        // Restricts the target object's type to TForwarder. 
        // The meta-object we are forwarding to assumes that it gets an instance of TForwarder (see [1]).
        // We need to ensure that the assumption holds.
        private DynamicMetaObject AddRestrictions(DynamicMetaObject result)
        {
            var restricted = new DynamicMetaObject(
                result.Expression,
                BindingRestrictions.GetTypeRestriction(Expression, Value.GetType()).Merge(result.Restrictions),
                _metaForwardee.Value
                );
            return restricted;
        }
        // Forward all dynamic operations or some of them as needed //
        public override DynamicMetaObject BindGetMember(GetMemberBinder binder)
        {
            return AddRestrictions(_metaForwardee.BindGetMember(binder));
        }
        public override DynamicMetaObject BindSetMember(SetMemberBinder binder, DynamicMetaObject value)
        {
            return AddRestrictions(_metaForwardee.BindSetMember(binder, value));
        }
        public override DynamicMetaObject BindDeleteMember(DeleteMemberBinder binder)
        {
            return AddRestrictions(_metaForwardee.BindDeleteMember(binder));
        }
        public override DynamicMetaObject BindGetIndex(GetIndexBinder binder, DynamicMetaObject[] indexes)
        {
            return AddRestrictions(_metaForwardee.BindGetIndex(binder, indexes));
        }
        public override DynamicMetaObject BindSetIndex(SetIndexBinder binder, DynamicMetaObject[] indexes, DynamicMetaObject value)
        {
            return AddRestrictions(_metaForwardee.BindSetIndex(binder, indexes, value));
        }
        public override DynamicMetaObject BindDeleteIndex(DeleteIndexBinder binder, DynamicMetaObject[] indexes)
        {
            return AddRestrictions(_metaForwardee.BindDeleteIndex(binder, indexes));
        }
        public override DynamicMetaObject BindInvokeMember(InvokeMemberBinder binder, DynamicMetaObject[] args)
        {
            return AddRestrictions(_metaForwardee.BindInvokeMember(binder, args));
        }
        public override DynamicMetaObject BindInvoke(InvokeBinder binder, DynamicMetaObject[] args)
        {
            return AddRestrictions(_metaForwardee.BindInvoke(binder, args));
        }
        public override DynamicMetaObject BindCreateInstance(CreateInstanceBinder binder, DynamicMetaObject[] args)
        {
            return AddRestrictions(_metaForwardee.BindCreateInstance(binder, args));
        }
        public override DynamicMetaObject BindUnaryOperation(UnaryOperationBinder binder)
        {
            return AddRestrictions(_metaForwardee.BindUnaryOperation(binder));
        }
        public override DynamicMetaObject BindBinaryOperation(BinaryOperationBinder binder, DynamicMetaObject arg)
        {
            return AddRestrictions(_metaForwardee.BindBinaryOperation(binder, arg));
        }
        public override DynamicMetaObject BindConvert(ConvertBinder binder)
        {
            return AddRestrictions(_metaForwardee.BindConvert(binder));
        }
    }
