    [TestClass]
    public class UrlHelperTest {
        [TestMethod]
        public void MockUrlHelper() {
            //Arrange            
            var expectedPath = "~/Path/To/File";
            var expectedContent = "<p>Fake content here<p>";
            var urlHelperMock = new Mock<UrlHelper>();
            urlHelperMock
                .Setup(m => m.Content(expectedPath))
                .Returns(expectedContent)
                .Verifiable();
    
            var sut = new ExampleController();
            sut.Url = urlHelperMock.Object; //Set mock UrlHelper        
    
            //Act
            var actualContent = sut.GetContent();
    
            //Assert
            urlHelperMock.Verify();
            Assert.AreEqual(expectedContent, actualContent);
        }
    }
