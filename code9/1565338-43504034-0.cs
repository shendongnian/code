    Action<MyClass,MyClass> CreateMethod(string propertyName){
       var mc1 = Expression.Parameter(typeof(MyClass));
       var mc2 = Expression.Parameter(typeof(MyClass));
       var p1 = Expression.Property(mc1, propertyName);
       var p2 = Expression.Property(mc2, propertyName);
       var assign = Expression.AddAssign(p1,p2);
    
       return Expression.Lambda<Action<MyClass,MyClass>>
                (assign,mc1,mc2).Compile();
    }
