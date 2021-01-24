    public class MyClass {
        private Lazy<IHelper> _helper = new Lazy<IHelper>(() => new Helper());
        private IHelper Helper {
            get => _helper.Value;
        }
    }
