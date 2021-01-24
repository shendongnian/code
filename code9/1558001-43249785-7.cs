     [TestClass]
        public class TestClassWithParamsInCtorClass
        {
            [TestMethod]
            //Wrong data type test
            public void WrongInputDataTypesTest()
            {
                //Arrange
                var inputData = new object[] { new[] { 1, 2 }, "" };
                var inputDataTypes = inputData.Select(_ => _.GetType());
    
                //Act
                var matchedCtorParams = typeof(ClassWithParamsInCtor)
                                       .GetConstructors()
                                       .Select(_ => _.GetParameters().Select(a => a.ParameterType))
                                       .Where(_ => _.HaveSameItems(inputDataTypes)).ToArray();
    
                //Assert 
                Assert.AreEqual(null, matchedCtorParams.FirstOrDefault());
            }
    
            [TestMethod]
            //Test used to invoke first constructor
            public void InputDataTypesTest1()
            {
                //Arrange
                var inputData = new object[] { new[] { 1, 2 } , 1 };
                var inputDataTypes = inputData.Select(_ => _.GetType());
    
                //Act
                var matchedCtorParams = typeof(ClassWithParamsInCtor)
                                       .GetConstructors()
                                       .Select(_ => _.GetParameters().Select(a => a.ParameterType))
                                       .Where(_ => _.HaveSameItems(inputDataTypes)).ToArray();
    
               var result = typeof(ClassWithParamsInCtor).GetConstructor(matchedCtorParams.FirstOrDefault().ToArray())
                       .Invoke(inputData);
    
                //Assert 
                Assert.AreNotEqual(null, result);
    
            }
    
            [TestMethod]
            //Test used to invoke second constructor
            public void InputDataTypesTest2()
            {
                //Arrange
                var inputData = new object[] { new[] { 1, 2 }, 1.2 };
                var inputDataTypes = inputData.Select(_ => _.GetType());
    
                //Act
                var matchedCtorParams = typeof(ClassWithParamsInCtor)
                                       .GetConstructors()
                                       .Select(_ => _.GetParameters().Select(a => a.ParameterType))
                                       .Where(_ => _.HaveSameItems(inputDataTypes)).ToArray();
    
                var result = typeof(ClassWithParamsInCtor).GetConstructor(matchedCtorParams.FirstOrDefault().ToArray())
                        .Invoke(inputData);
    
                //Assert 
                Assert.AreNotEqual(null, result);
    
            }
    
            [TestMethod]
            //Test used to invoke third constructor
            public void InputDataTypesTest3()
            {
                //Arrange
                var inputData = new object[] { new[] { 1, 2 }, 3.5F };
                var inputDataTypes = inputData.Select(_ => _.GetType());
    
                //Act
                var matchedCtorParams = typeof(ClassWithParamsInCtor)
                                       .GetConstructors()
                                       .Select(_ => _.GetParameters().Select(a => a.ParameterType))
                                       .Where(_ => _.HaveSameItems(inputDataTypes)).ToArray();
    
                var result = typeof(ClassWithParamsInCtor).GetConstructor(matchedCtorParams.FirstOrDefault().ToArray())
                        .Invoke(inputData);
    
                //Assert 
                Assert.AreNotEqual(null, result);
    
            }
        }
