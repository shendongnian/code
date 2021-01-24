    var driveTimeService = new DriveTimeService();
            var mock = new Mock<IHasDriveTimes>().SetupAllProperties();
            mock.Object.StartDateTime = DateTimeOffset.Now.Date;
            mock.Object.StopDateTime = mock.Object.StartDateTime + TimeSpan.FromHours(2);
            driveTimeService.Initialize(mock.Object);
            mock.Object.StartDateTime += TimeSpan.FromHours(1);
            mock.Raise(t => t.PropertyChanged += It.IsAny<PropertyChangedEventHandler>(), new PropertyChangedEventArgs(mock.Object.GetPropertyName(t => t.StartDateTime)));
            Assert.AreEqual(mock.Object.StartDateTime + TimeSpan.FromHours(2), mock.Object.StopDateTime);
