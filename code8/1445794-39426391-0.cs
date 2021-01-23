     protected void NotifyPropertyChanged<T>(Expression<Func<T>> action)
            {
                var propertyName = GetPropertyName(action);
                NotifyPropertyChanged(propertyName);
            }
    
            private static string GetPropertyName<T>(Expression<Func<T>> action)
            {
                var expression = (MemberExpression)action.Body;
                var propertyName = expression.Member.Name;
                return propertyName;
            }
     private void NotifyPropertyChanged(string propertyName)
            {
                VerifyPropertyName(propertyName);
    
                var handler = PropertyChanged;
                if (handler == null) return;
    
                var e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
