    class X : ReactiveObject
    {
        public X()
        {
            var propertyName = "A";
            this.WhenAny(GetProperty<int>(propertyName), c => c.GetValue() * c.GetValue())
                .Subscribe(i => Console.WriteLine(i));
        }
        int _a;
        public int A
        {
            get { return _a; }
            set { this.RaiseAndSetIfChanged(ref _a, value); }
        }
        private Expression<Func<X, T>> GetProperty<T>(string propertyName)
        {
            ParameterExpression param = Expression.Parameter(typeof(X));
            Expression<Func<X, T>> expr = (Expression<Func<X, T>>)Expression.Lambda(
                Expression.Property(param, propertyName),
                param
            );
            return expr;
        }
    }
