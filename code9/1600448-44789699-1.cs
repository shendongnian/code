    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class DataTestMethodWithTestInputsFromClassPropertyAttribute : DataTestMethodWithProgrammaticTestInputs
    {
        private Type _typeWithIEnumerableOfDataItems;
        private string _nameOfPropertyWithData;
        public DataTestMethodWithTestInputsFromClassPropertyAttribute(
            Type typeWithIEnumerableOfDataItems,
            string nameOfPropertyWithData)
            : base()
        {
            _typeWithIEnumerableOfDataItems = typeWithIEnumerableOfDataItems;
            _nameOfPropertyWithData = nameOfPropertyWithData;
        }
        protected override IEnumerable GetTestInputs()
        {
            object instance;
            var defaultConstructor = _typeWithIEnumerableOfDataItems.GetConstructor(Type.EmptyTypes);
            if (defaultConstructor != null)
                instance = defaultConstructor.Invoke(null);
            else
                instance = FormatterServices.GetUninitializedObject(_typeWithIEnumerableOfDataItems);
            var property = _typeWithIEnumerableOfDataItems.GetProperty(_nameOfPropertyWithData);
            if (property == null)
                throw new Exception($"Failed to find property named {_nameOfPropertyWithData} in type {_typeWithIEnumerableOfDataItems.Name} using reflection.");
            var getMethod = property.GetGetMethod(true);
            if (property == null)
                throw new Exception($"Failed to find get method on property named {_nameOfPropertyWithData} in type {_typeWithIEnumerableOfDataItems.Name} using reflection.");
            try
            {
                return getMethod.Invoke(instance, null) as IEnumerable;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed when invoking get method on property named {_nameOfPropertyWithData} in type {_typeWithIEnumerableOfDataItems.Name} using reflection.  Exception was {ex.ToString()}");
            }
        }
    }
