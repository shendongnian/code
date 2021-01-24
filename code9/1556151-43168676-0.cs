    //Arrange
    var settings = new JsonSerializerSettings {
                       DateFormatString = "yyyy", // <-- THIS IS THE DESIRED FORMAT
                   };
    var json = "{ \"MyPartialDate\": \"2005\" }";
    var expected = 2005;
    //Act
    var actual = JsonConvert.DeserializeObject<PartialDateContainter>(json, settings);
    //Assert
    Assert.IsNotNull(actual);
    Assert.AreEqual(expected, actual.MyPartialDate.Year);
