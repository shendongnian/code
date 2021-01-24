    public class LocResourceKey {
        // constructor is private
        private LocResourceKey(string key) {
            Key = key;
        }
        public string Key { get; }
        // the only way to get an instance of this type is
        // through below properties
        public static readonly LocResourceKey Load = new LocResourceKey("Load");
        public static readonly LocResourceKey Save = new LocResourceKey("Save");
    }
    public class MyMarkupExtension : MarkupExtension {
        private readonly string _input;
        public MyMarkupExtension(LocResourceKey input) {
            _input = input.Key;
        }
        public override object ProvideValue(IServiceProvider serviceProvider) {
            return Resources.ResourceManager.GetString(_input);
        }
    }
