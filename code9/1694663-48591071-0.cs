[Test]
public void TestSomething()
{
  // Arrange
  var barMock = RhinoMocks.MockRepository.GenerateStrictMock<IBar>();
  var foo = new Foo(bar);
  // Act
  foo.DoSomething();
  // Assert
  ...
