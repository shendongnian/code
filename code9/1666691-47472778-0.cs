    // A concrete implementation you will use at runtime.
    public class FileHelper : IFileHelper
    {
    	bool DirectoryExists(string location) => Directory.Exists(location);
    	string ReadAlltext(string location) => File.ReadAllText(location);
    	void WriteAlLText(string location, string text) => File.WriteAlLText(location, text);
    }
    public interface IFileHelper
    {
    	bool DirectoryExists(string location);
    	string ReadAlltext(string location);
    	WriteAllText(string location, string text);
    }
    [TestMethod]
    public void TestDeleteShow()
    {
        // Create a mock of your FileHelper and setup
        // the methods and what you want them to return.
    	Mock<IFileHelper> fileHelper = new Mock<IFileHelper>();
    	fileHelper.Setup(x=>x.DirectoryExists).Returns(true);
    	fileHelper.Setup(x=>x.ReadAllText).Returns( /* put some text in here */);
    	string testLocation = "foo";
    	Foo.DeleteShow(testLocation);
    	
        // Verify the methods on your mock were called, as expected.
    	fileHelper.Verify(x=>x.WriteAlLText(It.IsAny<string>(), string.Empty));
    }
