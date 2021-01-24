    Mock<IDataProtector> mockDataProtector = new Mock<IDataProtector>();
    mockDataProtector.Setup(sut => sut.Protect(It.IsAny<byte[]>())).Returns(Encoding.UTF8.GetBytes("protectedText"));
    mockDataProtector.Setup(sut => sut.Unprotect(It.IsAny<byte[]>())).Returns(Encoding.UTF8.GetBytes("originalText"));
    
    Mock<IDataProtectionProvider> mockDataProtectionProvider = new Mock<IDataProtectionProvider>();
    mockDataProtectionProvider.Setup(s => s.CreateProtector(It.IsAny<string>())).Returns(mockDataProtector.Object);
