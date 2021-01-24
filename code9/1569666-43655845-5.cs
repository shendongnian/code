    public class DiskDeliveryBOTests {
        [Test]
        public void TrackPublicationChangesOnCDSTest() {
            //Arrange
            var expected = 0;
            var commonMock = new Mock<ICommonCalls>();
            //...Setup commonMock desired behavior
            var daoMock = new Mock<IDiskDeliveryDAO>();
            //...Setup daoMock desired behavior
            daoMock
                .Setup(_ => _.TrackPublicationChangesOnCDS(It.IsAny<List<string>>())
                .Returns(expected);
            var fileMock = new Mock<IFileSystem>();
            //...Setup fileMock desired behavior
            
            var objDiskDeliveryBO = new DiskDeliveryBO(commonMock.Object, daoMock.Object, fileMock.Object);
            //Act
            var actualResult = objDiskDeliveryBO.TrackPublicationChangesOnCDS();
            //Assert             
            Assert.AreEqual(expected, actualResult);
        }
    }
