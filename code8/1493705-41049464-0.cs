        [TestClass]
        public class UnitTest1
        {
            public interface ITestInterface
            {
                int Bar { get; set; }
                void Foo(int foo);
            }
    
    
            [TestMethod]
            public void TestMethod1()
            {
                Mock<ITestInterface> mock = new Mock<ITestInterface>(MockBehavior.Strict);
                mock.Setup(a => a.Foo(3));
                mock.Setup(a => a.Bar)
                    .Returns(3);
    
    
                bool t1 = mock.HasSetupFor((m) => m.Foo(3));
                bool t2 = mock.HasSetupFor((m) => m.Bar);
            }
        }
    
        public static class MockExtension
        {
            public static bool HasSetupFor<T>(this Mock<T> value, Action<T> expression) where T : class
            {
                if (value.Behavior != MockBehavior.Strict)
                    throw new InvalidOperationException("Behaviour must be strict");
    
                bool hasSetup = true;
    
                try
                {
                    expression(value.Object);
                }
                catch(MockException)
                {
                    hasSetup = false;
                }
    
                return hasSetup;
            }
    
            public static bool HasSetupFor<TMock, TResult>(this Mock<TMock> value, Func<TMock, TResult> expression) where TMock : class
            {
                if (value.Behavior != MockBehavior.Strict)
                    throw new InvalidOperationException("Behaviour must be strict");
    
                bool hasSetup = true;
    
                try
                {
                    TResult tmp = expression(value.Object);
                }
                catch (MockException)
                {
                    hasSetup = false;
                }
    
                return hasSetup;
            }
        }
