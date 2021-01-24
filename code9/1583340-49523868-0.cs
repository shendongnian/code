	[Fact]
	public void Test()
	{
		using (var mock = AutoMock.GetLoose())
		{
			var moqMockMe = new Mock<MockMe>();
			moqMockMe.Setup(s => s.AmIMocked()).Returns("Yes");
			mock.Provide(moqMockMe.Object);
			var lifeTimeScope = mock.Create<ILifetimeScope>();
			using (var scope = lifeTimeScope.BeginLifetimeScope())
			{
				var mockMeInsideScope = scope.Resolve<MockMe>();
				var actual = mockMeInsideScope.AmIMocked();
				Assert.Equal("Yes", actual);
			}
		}
	}
	public interface MockMe
	{
		string AmIMocked();
	}
	public class MockMeImpl : MockMe
	{
		public string AmIMocked()
		{
			return "No";
		}
	}
