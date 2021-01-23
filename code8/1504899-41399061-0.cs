    [TestClass]
    public class MoqVerifyExceptionWithoutInterface {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ModelWrapperThrowsOnNullModel() {
            var mock = new Mock<ModelWrapper>(MockBehavior.Strict, null);
            try {
                var model = mock.Object;
            } catch (TargetInvocationException e) {
                if (e.InnerException != null)
                    throw e.InnerException;
                throw;
            }
        }
        public class ModelWrapper {
            private Customer _customer;
            public ModelWrapper(Customer model) {
                if (model == null)
                    throw new ArgumentNullException("model");
                _customer = model;
            }
        }
        public class Customer { }
    }
