     public abstract class StubsCreatorAbstract
    {
        public Mock<T> GenerateObject<T>() where T : class 
        {
            var mock = new Mock<T>();
            return mock;
        }
        public Mock<D> SetupValue<T, D>(Mock<D> stub, string nameOfField, T value) where D : class
        {
            var field = typeof(D).GetProperty(nameOfField);
            if (field == null)
            {
                throw new ArgumentException("Field do not exist");
            }
            field.SetValue(stub.Object, value);
            return stub;
        }
    }
