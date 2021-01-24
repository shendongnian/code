    public class BarBase
    {
        private string _derivedClassName;
        public Foo Value
        {
            get
            {
                if (string.IsNullOrEmpty(_derivedClassName))
                {
                    return null;
                }
                var fooType = typeof(Foo).Assembly.GetTypes().FirstOrDefault(x => x.Name == "Foo" + _derivedClassName.Substring(_derivedClassName.Length - 1, 1));
                if (fooType == null)
                {
                    return null;
                }
                return Activator.CreateInstance(fooType) as Foo;
            }
        }
        public BarBase(string derivedClassName)
        {
            _derivedClassName = derivedClassName;
        }
    }
