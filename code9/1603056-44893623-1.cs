    // In example used
    // NUnit as test framework
    // FluentAssertions as assertion framework
    
    [TestFixture]
    public class MapperWrapperTests
    {
        [Test]
        public void Map_ShouldReturnInstanceWithCorrectValueOfAProperty()
        {
            var expectedA = 42;
            var input = new { A = expectedA };
            var actualResult = MapperWrapper.Map(input);
 
            actualResult.A.Should().Be(expectedA);
        }
        // FluentAssertions framework provide "deep object graph" assertion
        [Test]
        public void Map_ShouldReturnInstanceWithCorrectValues()
        {
            var expectedResult = new Dest
            {
                Id = 42,
                Name = "Forty-Two",
                SomeAnotherType = new AnotherType { IsValid = true }
            };
            var input = new 
            { 
                Id = "42",
                Name = "Forty-Two",
                SomeAnotherType = new { IsValid = true }
            };
            var actualResult = MapperWrapper.Map(input);
 
            actualResult.ShouldBeEquivalentTo(expectedResult);
        }
    }
