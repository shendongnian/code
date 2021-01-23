    [TestClass]
    public class TimeDistanceTests {
        //change these to the needed types
        object Location1;
        object Location2;
        object expected;
        [TestInitialize]
        public void Init() {
            //...setup the two locations and expectations
            Location1 = //...
            Location2 = //...
            expected = //...the distance.
        }
    
        [TestMethod]
        public void Check_Distance_Between_Two_Locations_Using_WCF() {
            //Arrange
            var sut = new WCFTimeDistance();
            //Act
            var actual = sut.CalculateDistance(Location1, Location2);
            //Assert
            //...some assertion proving that test passes or failed
            Assert.AreEqual(expected, actual);
        }
    
        [TestMethod]
        public void Check_Distance_Between_Two_Locations_Using_API() {
            //Arrange
            var sut = new APITimeDistance();
            //Act
            var actual = sut.CalculateDistance(Location1, Location2);
            //Assert
            //...some assertion proving that test passes or failed
            Assert.AreEqual(expected, actual);
        }
    }
