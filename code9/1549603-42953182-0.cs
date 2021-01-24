            var mockFileProcessor = new Mock<IFileProcessor>(); //here is how I mocked my AttachmentProcessor
            var mockAttachmentInfo = new Mock<IFileInfo>(); ///here is how I mocked my AttachmentInfo
            mockAttachmentInfo.Setup(m => m.Length).Returns(() => 200);
            mockFileProcessor.Setup(m => m.FileList).Returns(() => new List<IFileInfo> 
            {
             mockAttachmentInfo.Object,
             mockAttachmentInfo.Object,
             mockAttachmentInfo.Object, 
             mockAttachmentInfo.Object,
             mockAttachmentInfo.Object 
            }); /// and this is the part where I mocked my IList<AttachmentInfo>
