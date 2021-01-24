    public void Should_Add_Logs()
    {
        
        //arrange
        var fileRepoMock = new Mock<IRepository<FileTable>>();
        
        var importer = new Importer(fileRepoMock.Object,...);
        
        //action
        importer.Process("path");
        
        //assert
        fileRepoMock.Verify(r=>r.Add(It.IsAny<FileTable>(),Times.AtMostOnce());
    }
