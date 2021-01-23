    public class SomeClass 
    {
        public Model _model { get; private set; }
        // Constructor will sure, that class get an instance of IModel
        public SomeClass(IModel model) 
        {
            _model = model; 
        }
        public void Foo() 
        {
            _model.DoSomethingHeavy();
        }
    }
