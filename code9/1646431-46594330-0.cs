    [TestFixture]
    public class MyTests {
      [Test]
      public void YourTest() {
        var number = 0;
        number = myPageObjectModel.GetResultCount();
        myPageObjectModel.Delete();
        Assert.AreEqual(number - 1, myPageObjectModel.GetResultCount());
      }
    }
