    using System.Reflection;
    using System.Linq.Expressions;
    
    void Stub() { }
    
    object GetInstance(Expression<Action> expr)
    {
        var invoke = (MethodCallExpression)expr.Body;
        return ((ConstantExpression)invoke.Object).Value;
    }
    
    var This = GetInstance(() => Stub());
