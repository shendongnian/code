    public class MyClass
    {
        void DoSomethingThatRequiresTheFieldINeed()
        {
            var value = _theField.Value;
        }
        // or
        SomeType PropertyThatExposesTheField => _theField;
    }
