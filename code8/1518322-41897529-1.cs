    using System;
    using System.Linq.Expressions;
    
    namespace SomeNS
    {
        public partial class SomeClassExprs
        {
            public static Expression<Func<SomeClass,object>> FooExpr = _ => _.Foo;
        }
    }
