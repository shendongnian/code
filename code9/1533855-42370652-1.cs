    [TestClass]
    public class TestUserProjects {
        [TestMethod]
        public void GetUserProjectsTest() {
            // Arrange
            var controller = new UserProjectController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();
    
            foreach (var testUserId in GetTestUserIds()) {
                //Arrange specific user
                var identity = new GenericIdentity(testUserId, "");
                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, testUserId.ToString()));
                identity.AddClaim(new Claim(ClaimTypes.Name, testUserId.ToString()));
                var principal = new GenericPrincipal(identity, roles: new string[] { });
                var user = new ClaimsPrincipal(principal);
                controller.User = user;
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
