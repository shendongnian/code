    var messageBox = new Mock<IMessageSvc>();
    messageBox.Setup(x => x.Show(It.Is<string>(y => y == "Do you want to save changes?"),
    	It.Is<string>(y => y == "Save Changes"),
    	It.Is<MessageBoxButton>(y => y == MessageBoxButton.YesNoCancel),
    	It.Is<MessageBoxIcon>(y => y == MessageBoxIcon.Question),
    	It.Is<MessageBoxResult>(y => y == MessageBoxResult.Yes)))
    	.Returns(MessageBoxResult.Yes);
   
    mainViewModel.CloseCommand.Execute(new object());
    	
    messageBox.Verify(x => x.Show(It.Is<string>(y => y == "Do you want to save changes?"),
    	It.Is<string>(y => y == "Save Changes"),
    	It.Is<MessageBoxButton>(y => y == MessageBoxButton.YesNoCancel),
    	It.Is<MessageBoxIcon>(y => y == MessageBoxIcon.Question),
    	It.Is<MessageBoxResult>(y => y == MessageBoxResult.Yes)));
