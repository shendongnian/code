      [TestFixture]
      public class Class1
      {
        [Test]
        public void Sort_WhenCalled_CallsWithPassedArgument()
        {
          // Arrange
          IMyInterface mock = Substitute.For<IMyInterface>();
    
          Func<IEnumerable<int>, IOrderedEnumerable<int>> func = null;
          mock.WhenForAnyArgs(x => x.Sort(Arg.Any<Func<IEnumerable<int>, IOrderedEnumerable<int>>>())).Do(
            x =>
              {
                func = x.Arg<Func<IEnumerable<int>, IOrderedEnumerable<int>>>();
              });
    
          // Act
          mock.Sort(x => x.OrderBy(y => y));
    
          // Assert
          var result = func(new[] { 6, 4 });
          
          Assert.That(result.FirstOrDefault(), Is.Not.EqualTo(6));
          Assert.That(result.FirstOrDefault(), Is.EqualTo(4));
        }
      }
