    public interface IFileScanner {
       List<string> GetAvailableFiles(string folder);
    }
    
    [Test]
    public void GetAvailableFiles_EmptyFolder_ReturnsEmptyList()
    {     
       // Arrange
       IFileScanner scanner = new FileScannerEmptyFolderStub();
       // Act
       var list = scanner.GetAvailableFiles("dummy argument");
       // Assert
       Assert.IsTrue(list.Count == 0);
    }
