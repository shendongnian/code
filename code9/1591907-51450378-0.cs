    using System.Linq;
    using System.Linq.Expressions;
    using Moq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    
    public static class MoqExtensions
    {
        public static bool WasMethodSetup(this Mock mock, string method)
        {
            var moqSetups = new PrivateObject(new PrivateObject(mock).GetProperty("Setups")).Invoke("ToArray") as object[];
            var moqExpressions = moqSetups.Select(s => new PrivateObject(s).GetProperty("SetupExpression") as LambdaExpression);
            return moqExpressions.Where(e => e.Body.NodeType == ExpressionType.Call)
                    .Select(b => new PrivateObject(new PrivateObject(b.Body).GetProperty("Method")).GetProperty("Name"))
                    .Contains(method);
        }
    }
