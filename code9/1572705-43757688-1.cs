	public class CustomerServiceTest
	{
		[Test]
		public void GetResellerCustomersWithProperties_ReturnsFromCortextBusinessManager()
		{
			//arrange
			var mockCortexBusinessManager = new Mock<ICortexBusinessManager>();
			//if GetResellerCustomersWithProperties is called with s123, return a new list of CustomerViewModel
			//with one item in, with id of 1
			mockCortexBusinessManager.Setup(m=> m.GetResellerCustomersWithProperties("s123"))
				.Returns(new List<CustomerViewModel>(){new CustomerViewModel{Id = 1}});
			var customerService = new CustomerService(mockCortexBusinessManager.Object);
			//act
			var result = customerService.GetResellerCustomersWithProperties("s123");
			//assert
			Assert.AreEqual(1, result.Count())
			Assert.AreEqual(1, result.FirstOrDefault().Id)
		}
	} 
