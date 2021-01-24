    public class MyClass
    {
        public MyClass() { }
        public MyClass(MyClass baseInstance)
        {
            var fields = typeof(MapObject).GetFields();
            foreach (var field in fields)
                field.SetValue(this, field.GetValue(baseInstance));
            var props = typeof(BaseItems).GetProperties();
            foreach (var prop in props)
                if (prop.CanWrite)
                    prop.SetValue(this, prop.GetValue(baseInstance));
        }
    }
