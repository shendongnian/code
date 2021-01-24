    [TestFixture]
    [Category("Unit")]
    public class DeviceGroupManagerBaseTests
    {
        private IFixture fixture;
        private Mock<DeviceGroupManagerBase<DeviceGroup>> subject;
        private Mock<IDeviceGroupDao<DeviceGroup>> deviceGroupDaoMock;
        private DeviceGroupManagerBase<DeviceGroup> Manager => subject.Object;
        [OneTimeSetUp]
        public void Init()
        {
            fixture = new Fixture().Customize(new AutoMoqCustomization());
            deviceGroupDaoMock = fixture.Freeze<Mock<IDeviceGroupDao<DeviceGroup>>>();
            subject = fixture.Freeze<Mock<DeviceGroupManagerBase<DeviceGroup>>>();
            subject.SetupGet(x => x.DeviceGroupDao).Returns(deviceGroupDaoMock.Object);
        }
        [Test]
        public void TestUpdateDeviceIndexes()
        {
            var device = fixture.Create<Device>();
            var deviceGroup = fixture.Create<DeviceGroup>();
            deviceGroupDaoMock.Setup(x => x.GetDeviceGroup(It.IsAny<int>())).Returns(deviceGroup);
            var result = Manager.UpdateDeviceIndexes(device);
            Assert.AreEqual(deviceGroup.Id, result.Id);
        }
    }
