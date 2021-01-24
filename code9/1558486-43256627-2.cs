    // Same UnityRegistrer class is located in the regular library.
    // Same UnityRegistrerTest class, but is located in the test assembly.
    // In the actual test class where you want to override the registration
	[TestClass]
    public class WhateverUnitTest
    {
        IUnityContainer container;
        [TestInitialize]
        public void TestClassInitialization()
        {
			UnityContainer container = new UnityContainer();
			UnityRegistrer.Register(container);
			UnityRegistrerTest.Register(container);
		}
		
		[TestMethod]
		public void Blahhhhhh
		{
			//Arrange
			ICommunicationGate communicationGate = container.Resolve<ICommunicationGate>("ImplementationOne");
			
			//Act
			...
			
			//Assert
			...
		}
	}
