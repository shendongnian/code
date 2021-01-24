    using NUnit.Framework;
    
    [TestFixture]
    public class MyAppTests
    {
        [Test]
        [RunIfTheSoftwareInstalledOnTheMachine]
        public void ATestMethod()
        {
            // Executes if custom attribute is true, otherwise test case is ignored
        }
    }
