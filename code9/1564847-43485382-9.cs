    class TestModel
    {
        public string displayValue;
        public override bool Equals(object obj)
        {
            if (obj.GetType() != typeof(TestModel))
                    return false;
            var testObj = obj as TestModel;
            return testObj?.GetHashCode() == testValue?.GetHashCode();
        }
        public override int GetHashCode()
        {
            return displayValue.GetHashCode();
        }
    }
