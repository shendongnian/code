    [Test]
    public void SetDeviceNameOnLoad() {
        //Arrange 
        var device = Substitute.For<IDeviceLogic>();
        var view = Substitute.For<IDeviceView>();
        var form = new DevicePresenter(device, deviceView);
        device.GetHostName("IP Address","Object Identifier Repository","CommunityString").Returns("sample device name");
        //Act   
        form.Load();
        //Assert
        Assert.AreEqual("sample device name", view.DeviceName);
    }
