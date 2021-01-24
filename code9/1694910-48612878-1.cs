    [TestClass]
	public class ContrastControlViewModelTests
	{
		[TestMethod]
		public void UpdateCompositePropertyValues_Should_update_contrast_curve_when_ContrastCurve_and_enabled()
		{
			//Arrange:
			IUpdateContrastCurveService updateContrastCurveService = new Mock<IUpdateContrastCurveService>();
			var vm = new ContrastControlViewModel(updateContrastCurveService.Object);
			var propertyName = "ContrastCurve";
			//Act:
			vm.UpdateCompositePropertyValues(propertyName);
			//Assert:
			Assert.IsTrue(updateContrastCurveService.Verify(x=>x.UpdateContrastCurve()));       
		}
	}
