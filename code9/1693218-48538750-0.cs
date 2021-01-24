    using Microsoft.Extensions.Localization;
    public class MyStringLocalizer<T> : StringLocalizer<T>
    {
        public MyStringLocalizer(IStringLocalizerFactory factory) : base(factory)
        {
        }
        public override LocalizedString this[string name]
        {
            get
            {
                //Log typeof(T) and name
                return base[name];
            }
        }
        public override LocalizedString this[string name, params object[] arguments]
        {
            get
            {
                //Log typeof(T) and name
                return base[name, arguments];
            }
        }
    }
