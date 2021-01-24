	[TestClass]
	public class TestUserProjects
	{
		[TestMethod]
		public void GetUserProjectsTest()
		{
			// Arrange
			var userProviderMock = new Mock<IUserProvider>();
			userProviderMock.Setup(userProvider => userProvider.GetUserId())
							.Returns("4e934c03-b02f-47bf-8bdf-e1c98a737cc6");
			var controller = new UserProjectController(userProviderMock.Object);
			controller.Request = new HttpRequestMessage();
			controller.Configuration = new HttpConfiguration();
			foreach (var testUserId in GetTestUserIds())
			{
				// Act
				var response = controller.GetProjects();
				// Assert
				List<ProjectDto> projects;
				Assert.IsTrue(response.TryGetContentValue<List<ProjectDto>>(out projects));
				//Assert.AreEqual(5, projects.Count); // Check projects count
				Assert.AreEqual(HttpStatusCode.OK,response.StatusCode);
				Assert.AreEqual(HttpStatusCode.OK, response.StatusCode,"GetUserProjects : id is {0} and count is {1}",testUserId,projects.Count);
				System.Diagnostics.Debug.WriteLine("GetUserProjects : for id {0} ProjectCount = {1}", testUserId, projects.Count);
			}
		}
	}
