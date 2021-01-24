    public class DiskDeliveryBOTests {
        [Test]
        public void TrackPublicationChangesOnCDSTest() {
            //Arrange
            var commonMock = new Mock<ICommonCalls>();
            //...Setup desired behavior
            var daoMock = new Mock<IDiskDeliveryDAO>();
            //...Setup desired behavior
            var fileMock = new Mock<IFileSystem>();
            //...Setup desired behavior
            
            var objDiskDeliveryBO = new DiskDeliveryBO(commonMock.Object, daoMock.Object, fileMock.Object);
            //Act
            var actualResult = objDiskDeliveryBO.TrackPublicationChangesOnCDS();
            //Assert 
            var expectedZipName = 0;
            Assert.AreEqual(expectedZipName, actualResult);
        }
    }
