    public void DoSomethingOnProperty<T>(Expression<Func<T, dynamic>> propertyName) where T : class, new()
        {
            var object1 = Activator.CreateInstance(typeof(T));
            var methodName = (propertyName.Body as MemberExpression).Member.Name;
            var propertyInfo = typeof(T).GetType().GetProperty(methodName);
            typeof(T).GetProperty(methodName).SetValue(object1, Convert.ChangeType("Test string", propertyInfo.PropertyType));
            //DoSomethingOnProperty(object1.thesameproperty...)
        }
