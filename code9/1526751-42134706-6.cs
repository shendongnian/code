    [TestFixture(TestName = "Tests")]
    public class Tests {
        private Mock<IUtilScv> utilScvMOCK;
    
        [SetUp]
        public void Setup() {
            utilScvMOCK = new Mock<IUtilScv>();
        }
    
        [Test]
        public void serviceIsBPManagementForValidSource() {
            //Arrange
            var expectedClinicalElementValue = "Zedmed";
            utilScvMOCK
                .Setup(s => s.GetConfiguration())
                .Returns(expectedClinicalElementValue)
                .Verifiable();            
        
            var sut = new myRealClass(utilScvMOCK.Object);
    
            //Act
            var actualClinicalElementValue = sut.myworkingMethod();
        
            //Assert
            configHelperMOCK.Verify();
            Assert.AreEqual(expectedClinicalElementValue, actualClinicalElementValue);
        }
    }
