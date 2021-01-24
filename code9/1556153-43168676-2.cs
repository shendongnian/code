    [TestClass]
    public class JsonNetDateSerializationTests {
        [TestMethod]
        public void JustCheckJsonDates() {
            //Arrange
            var settings =
                new JsonSerializerSettings {
                    DateFormatString = "yyyy", //<-- for year only dates. all others should parse fine
                };
            var json = "{ \"YearOnly\": \"2017\", \"YearMonth\": \"2017-04\", \"YearMonthDay\": \"2017-04-02\" }";
            var expected = 2017;
            //Act
            var actual = JsonConvert.DeserializeObject<PartialDateContainter>(json, settings);
            //Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected, actual.YearOnly.Year);
            Assert.AreEqual(expected, actual.YearMonth.Year);
            Assert.AreEqual(expected, actual.YearMonthDay.Year);
        }
        class PartialDateContainter {
            public DateTime YearOnly { get; set; }
            public DateTime YearMonth { get; set; }
            public DateTime YearMonthDay { get; set; }
        }
    }
