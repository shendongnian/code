    [AttributeUsage(AttributeTargets.Property, Inherited = false)]
    public class NavigationPropertyAttribute : Attribute
    {
        private int _priority;
        public NavigationPropertyAttribute()
        {
            _priority = 0;
        }
    
        public NavigationPropertyAttribute(int priority)
        {
            _priority = priority;
        }
        public int Priority { get { return _priority;} set {_priority = value;} }
    }
