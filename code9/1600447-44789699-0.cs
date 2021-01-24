    public abstract class DataTestMethodWithProgrammaticTestInputs : DataTestMethodAttribute
    {
        protected Lazy<IEnumerable> _items;
        public DataTestMethodWithProgrammaticTestInputs()
        {
            _items = new Lazy<IEnumerable>(GetTestInputs, true);
        }
        protected abstract IEnumerable GetTestInputs();
        public override TestResult[] Execute(ITestMethod testMethod)
        {
            var results = new List<TestResult>();
            foreach (var testInput in _items.Value)
            {
                var result = testMethod.Invoke(new object[] { testInput });
                var overriddenDisplayName = GetDisplayNameForTestItem(testInput);
                if (!string.IsNullOrEmpty(overriddenDisplayName))
                    result.DisplayName = overriddenDisplayName;
                results.Add(result);
            }
            return results.ToArray();
        }
        public virtual string GetDisplayNameForTestItem(object testItem)
        {
            return null;
        }
    }
