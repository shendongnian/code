    [Test]
    public void CreateFolderCommandMainVMTest() {
        //Arrange
        var mainVM = new MainVm();
        var foldeItem = new FolderItem();
        var command = (RelayCommand)mainVM.CreateFolderCommand;
        var expected = true;
        //Act
        bool canCreateFolder = command.CanExecute(folderItem);
        //Assert
        Assert.Equals(expected, canCreateFolder);
    }
