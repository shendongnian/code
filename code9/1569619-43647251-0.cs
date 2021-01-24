    /// <summary>
        /// create a getter delegate for a static field.
        /// </summary>
        /// <typeparam name="TField"></typeparam>
        /// <param name="staticType">the type that contains the field. </param>
        /// <param name="fieldName">the field that you want to get the value.</param>
        /// <returns>the getter delegate.</returns>
        public static Func<TField> CreateStaticFieldGetter<TField>(Type staticType, string fieldName)
        {
            var fieldInfo = staticType.GetField(fieldName, BindingFlags.NonPublic | BindingFlags.Static);
            var body = Expression.Field(null, fieldInfo);
            Expression<Func<TField>> lambda = Expression.Lambda<Func<TField>>(body);
            return lambda.Compile();
        }
        /// <summary>
        /// 为静态私有字段创建设置方法
        /// </summary>
        /// <typeparam name="TField"></typeparam>
        /// <param name="staticType"></param>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        public static Action<TField> CreateStaticFieldSetter<TField>(Type staticType, string fieldName)
        {
            ParameterExpression p1 = Expression.Parameter(typeof(TField), "p1");
            var fieldInfo = staticType.GetField(fieldName, BindingFlags.NonPublic | BindingFlags.Static);
            var leftExpr = Expression.Field(null, fieldInfo);
            var body = Expression.Assign(leftExpr, p1);
            Expression<Action<TField>> lambda = Expression.Lambda<Action<TField>>(body, p1);
            return lambda.Compile();
        }
        /// <summary>
        /// 为实例的私有字段创建读取方法
        /// </summary>
        /// <typeparam name="TField"></typeparam>
        /// <param name="staticType"></param>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        public static Func<TTarget, TField> CreateInstanceFieldGetter<TTarget, TField>(string fieldName)
        {
            ParameterExpression p1 = Expression.Parameter(typeof(TTarget), "p1");
            var fieldInfo = typeof(TTarget).GetField(fieldName, BindingFlags.NonPublic | BindingFlags.Instance);
            var body = Expression.Field(Expression.Convert(p1, typeof(TTarget)), fieldInfo);
            Expression<Func<TTarget, TField>> lambda = Expression.Lambda<Func<TTarget, TField>>(body, p1);
            return lambda.Compile();
        }
        /// <summary>
        /// 为实例的私有字段创建赋值方法
        /// </summary>
        /// <typeparam name="TTarget"></typeparam>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="filedName"></param>
        /// <returns></returns>
        public static Action<TTarget, TProperty> CreateInstanceFieldSetter<TTarget, TProperty>(string filedName)
        {
            ParameterExpression p1 = Expression.Parameter(typeof(TTarget), "p1");
            ParameterExpression p2 = Expression.Parameter(typeof(TProperty), "p2");
            var member = typeof(TTarget).GetField(filedName, BindingFlags.NonPublic | BindingFlags.Instance);
            var m1 = Expression.MakeMemberAccess(Expression.Convert(p1, typeof(TTarget)), member);
            BinaryExpression body = Expression.Assign(m1, p2);
            Expression<Action<TTarget, TProperty>> lambda = Expression.Lambda<Action<TTarget, TProperty>>(body, p1, p2);
            return lambda.Compile();
        }
