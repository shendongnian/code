    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    public static class IQueryableExtensions
    {
        public static IEnumerable<TModel> SelectAndAssign<TModel>(this IQueryable<TModel> source, Expression<Func<TModel, object>> assigner) where TModel : class, new()
        {
            //get typed body of original expression
            var originalBody = (MemberInitExpression)assigner.Body;
            //list to store the new bindings we're creating for new expression
            var newExpressionBindings = new List<MemberBinding>();
            var newExpressionReturnType = typeof(AnonymousType<TModel>);
            //new param
            var parameter = Expression.Parameter(typeof(TModel), "x");
            //base binding
            newExpressionBindings.Add(Expression.Bind(newExpressionReturnType.GetProperty("Item"), parameter));
            //go through all the original expression's bindings
            for (var i = 0; i < originalBody.Bindings.Count; i++)
            {
                var originalBinding = (MemberAssignment)originalBody.Bindings[i];
                var originalExpression = originalBinding.Expression;
                var memberType = originalBinding.Expression.Type;
                //create delegate based on the member type
                var originalLambdaDelegate = typeof(Func<,>).MakeGenericType(typeof(TModel), memberType);
                //create lambda from that delegate
                var originalLambda = Expression.Lambda(originalLambdaDelegate, originalExpression, assigner.Parameters[0]);
                //create a AnonymousVar<MemberType> from the type of the member ( to please EF unable to assign bool to object directly ) 
                //start with getting the generic type
                var genericMemberType = typeof(AnonymousVar<>).MakeGenericType(memberType);
                //then create teh delegate
                var genericMemberTypeDelegate = typeof(Func<>).MakeGenericType(genericMemberType);
                //Now create an expression with a binding for that object to assign its Property ( strongly typed now from the generic declaration )
                var genericInstantiationExpression = Expression.New(genericMemberType);
                //the binding.. using the original expression expression
                var genericInstantiationBinding = Expression.Bind(genericMemberType.GetProperty("Property"), originalLambda.Body);
                // create the body
                var genericInstantiationBody = Expression.MemberInit(genericInstantiationExpression, genericInstantiationBinding);
                //now we need to recreate a lambda for this
                var newBindingExpression = Expression.Lambda(genericMemberTypeDelegate, genericInstantiationBody);
                //Create the binding and add it to the new expression bindings
                newExpressionBindings.Add(Expression.Bind(newExpressionReturnType.GetProperty("Property" + (i + 1)), newBindingExpression.Body));
            }
            //start creating the new expression
            var expression = Expression.New(newExpressionReturnType);
            //create new expression body with bindings
            var body = Expression.MemberInit(expression, newExpressionBindings);
            //The actual new expression lambda
            var newLambda = Expression.Lambda<Func<TModel, AnonymousType<TModel>>>(body, parameter);
            // replace old lambda param with new one
            var replacer = new ParameterReplacer(assigner.Parameters[0], newLambda.Parameters[0]); // replace old lambda param with new
            //new lambda with fixed params
            newLambda = Expression.Lambda<Func<TModel, AnonymousType<TModel>>>(replacer.Visit(newLambda.Body), newLambda.Parameters[0]);
            //now that we have all we need form the server, we materialize the list
            var materialized = source.Select(newLambda).ToList();
            //typed return parameter
            var typedReturnParameter = Expression.Parameter(typeof(AnonymousType<TModel>), "x");
            //Lets assign all those custom properties back into the original object type
            var expressionLines = new List<Expression>();
            for (var i = 0; i < originalBody.Bindings.Count; i++)
            {
                var originalBinding = (MemberAssignment)originalBody.Bindings[i];
                var itemPropertyExpression = Expression.Property(typedReturnParameter, "Item");
                var bindingPropertyExpression = Expression.Property(itemPropertyExpression, originalBinding.Member.Name);
                var memberType = originalBinding.Expression.Type;
                var valuePropertyExpression = Expression.Convert(Expression.Property(typedReturnParameter, "Property" + (i + 1)), typeof(AnonymousVar<>).MakeGenericType(memberType));
                var memberValuePropertyExpression = Expression.Property(valuePropertyExpression, "Property");
                var equalExpression = Expression.Assign(bindingPropertyExpression, memberValuePropertyExpression);
                expressionLines.Add(equalExpression);
            }
            var returnTarget = Expression.Label(typeof(TModel));
            expressionLines.Add(Expression.Return(returnTarget, Expression.Property(typedReturnParameter, "Item")));
            expressionLines.Add(Expression.Label(returnTarget, Expression.Constant(null, typeof(TModel))));
            var finalExpression = Expression.Block(expressionLines);
            var typedReturnLambda = Expression.Lambda<Func<AnonymousType<TModel>, TModel>>(finalExpression, typedReturnParameter).Compile();
            return materialized.Select(typedReturnLambda);
        }
        class AnonymousVar<TModel>
        {
            public TModel Property { get; set; }
        }
        class AnonymousType<TModel>
        {
            public TModel Item { get; set; }
            public object Property1 { get; set; }
            public object Property2 { get; set; }
            public object Property3 { get; set; }
            public object Property4 { get; set; }
            public object Property5 { get; set; }
            public object Property6 { get; set; }
            public object Property7 { get; set; }
            public object Property8 { get; set; }
            public object Property9 { get; set; }
            public object Property10 { get; set; }
            public object Property11 { get; set; }
            public object Property12 { get; set; }
            public object Property13 { get; set; }
            public object Property14 { get; set; }
            public object Property15 { get; set; }
            public object Property16 { get; set; }
            public object Property17 { get; set; }
            public object Property18 { get; set; }
            public object Property19 { get; set; }
            public object Property20 { get; set; }
        }
        class ParameterReplacer : ExpressionVisitor
        {
            private ParameterExpression from;
            private ParameterExpression to;
            public ParameterReplacer(ParameterExpression from, ParameterExpression to)
            {
                this.from = from;
                this.to = to;
            }
            protected override Expression VisitParameter(ParameterExpression node)
            {
                return base.VisitParameter(node == this.from ? this.to : node);
            }
        }
    }
    
