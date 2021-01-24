    [TestClass]
    public class BirthDateValueObjectTests {
        public class Person {
            public DateTime BirthDate { get; set; }
        }
        public class PersonViewModel {
            public BirthDate BirthDate { get; set; }
        }
        string date = "1981-05-14";
        static BirthDateValueObjectTests() {
            AutoMapper.Mapper.Initialize(_ => {
            });
        }
        [TestMethod]
        public void BirthDate_Should_Implcit_Convert_From_DateTimeProperty() {
            //Arrange
            var birthDate = DateTime.Parse(date);
            var person = new Person {
                BirthDate = birthDate
            };
            var expected = new BirthDate(birthDate);
            
            var mapper = AutoMapper.Mapper.Instance;
            //Act
            var actual = mapper.Map<PersonViewModel>(person);
            //Assert
            actual.BirthDate
                .Should().NotBeNull()
                .And.Be(expected);
        }
        [TestMethod]
        public void BirthDate_Should_Implcit_Convert_To_DateTimeProperty() {
            //Arrange
            var birthDate = DateTime.Parse(date);
            var person = new PersonViewModel {
                BirthDate = new BirthDate(birthDate)
            };
            var expected = birthDate;
            var mapper = AutoMapper.Mapper.Instance;
            //Act
            var actual = mapper.Map<Person>(person);
            //Assert
            actual.BirthDate
                .Should().Be(expected);
        }
        [TestMethod]
        public void BirthDate_Should_Implicitly_ConvertTo_DateTime() {
            var expected = DateTime.Parse(date);
            var birthDate = new BirthDate(expected);
            DateTime actual = birthDate;
            actual.Should().Be(expected);
        }
        [TestMethod]
        public void BirthDate_Should_Implicitly_ConvertFrom_DateTime() {
            var birthDate = DateTime.Parse(date);
            var expected = new BirthDate(birthDate);
            BirthDate actual = birthDate;
            actual.Should().Be(expected);
        }
        [TestMethod]
        public void BirthDate_Should_Implicitly_ConvertTo_String() {
            var expected = DateTime.Parse(date);
            var birthDate = new BirthDate(expected);
            string actual = birthDate;
            actual.Should().Be(date);
        }
        [TestMethod]
        public void BirthDate_Should_Implicitly_ConvertFrom_String() {
            var birthDate = DateTime.Parse(date);
            var expected = new BirthDate(birthDate);
            BirthDate actual = date;
            actual.Should().Be(expected);
        }
    }
