    [TestFixture(TestName = "Tests")]
    public class Tests {
        private Mock<IConfigHelper> configHelperMOCK;
    
        [SetUp]
        public void Setup() {
            configHelperMOCK = new Mock<IConfigHelper>();
        }
    
        [Test]
        public void serviceIsBPManagementForValidSource() {
            //Arrange
            var sectionName = "sectionName/sectionElement";
            var clinicalElementName = "ClinicalSystem";
            var expectedClinicalElementValue = "Zedmed";
            configHelperMOCK
                .Setup(s => s.GetConfiguration(sectionName, clinicalElementName))
                .Returns(expectedClinicalElementValue)
                .Verifiable();            
        
            var sut = new myRealClass(configHelperMock.Object);
    
            //Act
            var actualClinicalElementValue = sut.myworkingMethod();
        
            //Assert
            configHelperMOCK.Verify();
            Assert.AreEqual(expectedClinicalElementValue, actualClinicalElementValue);
        }
    }
