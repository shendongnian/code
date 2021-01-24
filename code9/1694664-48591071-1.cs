[Test]
public void TestSomething()
{
  // Arrange
  var barMock = RhinoMocks.MockRepository.GenerateStrictMock<IBar>();
  var foo = new Foo(barMock);
  // Act
  foo.DoSomething();
  // Assert
  ...
