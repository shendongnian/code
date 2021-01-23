    static Action<object, object> CompileCopyMembersAction(Type sourceType, Type destinationType)
    {
        // Action input args: void Copy(object sourceObj, object destinationObj)
        var sourceObj = Expression.Parameter(typeof(object));
        var destinationObj = Expression.Parameter(typeof(object));
        var source = Expression.Variable(sourceType);
        var destination = Expression.Variable(destinationType);
        var bodyVariables = new List<ParameterExpression>
        {
            // Declare variables:
            // TSource source;
            // TDestination destination;
            source,
            destination
        };
        var bodyStatements = new List<Expression>
        {
            // Convert input args to needed types:
            // source = (TSource)sourceObj;
            // destination = (TDestination)destinationObj;
            Expression.Assign(source, Expression.ConvertChecked(sourceObj, sourceType)),
            Expression.Assign(destination, Expression.ConvertChecked(destinationObj, destinationType))
        };
        // TODO 1: Use reflection to go through TSource and TDestination,
        // find their members (fields and properties), and make matches.
        Dictionary<MemberInfo, MemberInfo> membersToCopyMap = null;
        foreach (var pair in membersToCopyMap)
        {
            var sourceMember = pair.Key;
            var destinationMember = pair.Value;
            // This gives access: source.MyFieldOrProperty
            Expression valueToCopy = Expression.MakeMemberAccess(source, sourceMember);
            // TODO 2: You can call a function that converts source member value type to destination's one if they don't match:
            // valueToCopy = Expression.Call(myConversionFunctionMethodInfo, valueToCopy);
            // TODO 3: Additionally you can call IClonable.Clone on the valueToCopy if it implements such interface.
            // Code: source.MyFieldOrProperty == null ? source.MyFieldOrProperty : (TMemberValue)((ICloneable)source.MyFieldOrProperty).Clone()
            //if (typeof(ICloneable).IsAssignableFrom(valueToCopy.Type))
            //    valueToCopy = Expression.IfThenElse(
            //        test: Expression.Equal(valueToCopy, Expression.Constant(null, valueToCopy.Type)),
            //        ifTrue: valueToCopy,
            //        ifFalse: Expression.Convert(Expression.Call(Expression.Convert(valueToCopy, typeof(ICloneable)), typeof(ICloneable).GetMethod(nameof(ICloneable.Clone))), valueToCopy.Type));
            // destination.MyFieldOrProperty = source.MyFieldOrProperty;
            bodyStatements.Add(Expression.Assign(Expression.MakeMemberAccess(destination, destinationMember), valueToCopy));
        }
        // The last statement in a function is: return true;
        // This is needed, because LambdaExpression cannot compile an Action<>, it can do Func<> only,
        // so the result of a compiled function does not matter - it can be any constant.
        bodyStatements.Add(Expression.Constant(true));
        var lambda = Expression.Lambda(Expression.Block(bodyVariables, bodyStatements), sourceObj, destinationObj);
        var func = (Func<object, object, bool>)lambda.Compile();
        // Decorate Func with Action, because we don't need any result
        return (src, dst) => func(src, dst);
    }
