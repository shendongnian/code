csharp
        private Expression WrapActionExpressionIn_Try_Catch_ThrowNewMessage(Expression coreExpression, string newMessage)
        {
            return
                Expression.TryCatch(
                    coreExpression,
                Expression.Catch(typeof(Exception),
                    Expression.Throw(
                        Expression.Constant(new Exception(newMessage))
                    )
                ));
        }
        private Expression WrapActionExpressionIn_Try_Catch_RethrowWithAdditionalMessage(Expression coreExpression, string additionalMessage)
        {
            var caughtExceptionParameter = Expression.Parameter(typeof(Exception));
            //We want to call `new Exception(additionalMessage, caughtException)`
            var ctorForExceptionWithMessageAndInnerException = typeof(Exception).GetConstructor(new[] {typeof(string), typeof(Exception)});
            var replacementExceptionExpresion = Expression.New(ctorForExceptionWithMessageAndInnerException, Expression.Constant(additionalMessage), caughtExceptionParameter);
            return
                Expression.TryCatch(
                    coreExpression,
                Expression.Catch(caughtExceptionParameter,
                    Expression.Throw( replacementExceptionExpresion )
                ));
        }
These two methods both start from a premise of "we already have an Expression representing an `Action<TInstance>` that we are about to invoke. And now we want to add a try-catch around that Action."
Without the Try-Catch, we would have done:
    Action finalLamda = Expression.Lambda<Action<TInstance>>(actionExpression, instanceExpression).Compile();
now we do:
    var actionWithTryCatchExpression = WrapActionExpressionIn_Try_Catch_RethrowWithAdditionalMessage(actionExpression);
    Action finalLamda = Expression.Lambda<Action<TInstance>>(actionWithTryCatchExpression, instanceExpression).Compile();
<hr>
Respectively the two helpers represent:
csharp
try
{
    action();
}
catch(Exception)
{
    throw new Exception(newMessage);
}
\\and
try
{
    action();
}
catch(Exception e)
{
    throw new Exception(additionalMessage, e);
}
