    public class SomeViewModel : BindableBaseExtended
    {
        private Person model;
        public Person Model
        {
            get { return model; }
            set { SetProperty(ref model, value); }
        }
        public string MyProperty
        {
            get { return Model.DisplayName; }
            set { SetProperty(Model, m => m.DisplayName, value); }
        }
    }
    public class BindableBaseExtended : BindableBase
    {
        protected virtual bool SetProperty<TClass, TMember>(TClass target, Expression<Func<TClass, TMember>> expression, TMember value, [CallerMemberName] string propertyName = null)
        {
            var expr = (MemberExpression)expression.Body;
            var prop = (PropertyInfo)expr.Member;
            var propValue = prop.GetValue(target, null);
            if (object.Equals(propValue, value)) return false;
            prop.SetValue(target, value, null);
            this.RaisePropertyChanged(propertyName);
            return true;
        }
        protected virtual bool SetProperty<TClass, TMember>(TClass target, Expression<Func<TClass, TMember>> expression, TMember value, Action onChanged, [CallerMemberName] string propertyName = null)
        {
            var expr = (MemberExpression)expression.Body;
            var prop = (PropertyInfo)expr.Member;
            var propValue = prop.GetValue(target, null);
            if (object.Equals(propValue, value)) return false;
            prop.SetValue(target, value, null);
            onChanged?.Invoke();
            this.RaisePropertyChanged(propertyName);
            return true;
        }
    }
