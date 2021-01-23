    [TestClass]
    public class UnitTest1 {
        [TestMethod]
        public void TestMethod1() {
            //Arrange
            var mock = Mock.Of<IAnnotationMapping>();
            var expectedCommandText = @"Insert Into AnnotationMapping Values 
                 (@AnnotationSetupId, @WordToAnnotate, 
                  @Annotation, @CreatedDttm, @CreatedUserId, @ModifiedDate, 
                  @ModifiedUserId, @IsActive)";
            string commandText = null;
            Dictionary<string, dynamic> parameters = null;
            int expectedParameterCount = 8;
            var sut = new AnnotationMappingQueryBuilder();
            //Act
            sut.ConstructAddMappingQuery(mock, out commandText, out parameters);
            //Assert
            Assert.IsNotNull(commandText);
            Assert.AreEqual(expectedCommandText, commandText);
            Assert.IsNotNull(parameters);
            Assert.AreEqual(expectedParameterCount, parameters.Count);
            ///what ever else you want to assert for parameters
        }
    }
