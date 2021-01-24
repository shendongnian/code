    [AttributeUsage(AttributeTargets.Field)]
    public class TrackedField : Attribute { }
    
    public class ATrackedObject
    {
        public ATrackedObject()
        {
            Type objType = this.GetType();
            foreach (FieldInfo f in objType.GetFields())
            {
                if (f.IsDefined(typeof(TrackedField), false)) {
                    if (f.FieldType == typeof(Action))
                    {
                        var currentValue = f.GetValue(this) as Action;
                        Action newValue = () =>
                        {
                            Console.WriteLine($"Tracking {f.Name}");
                            currentValue.Invoke();
                        };
    
                        f.SetValue(this, newValue);
                    }
                }
            }
        }
    
        [TrackedField]
        public Action SomeMethod = () => Console.WriteLine("Some Method Called");
    }
