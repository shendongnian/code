    public sealed class ReactiveCrossConnectivityTest : ReactiveTest
    {
        [Test]
        public void IsConnected_ThrottlesOnConnect()
        {
            var connectivity = Substitute.For<Plugin.Connectivity.Abstractions.IConnectivity>();
            connectivity.IsConnected.Returns(true);
            var testScheduler = new TestScheduler();
            var sut = new ReactiveCrossConnectivity(
                connectivity, new SingleSchedulerProvider(testScheduler));
            var isConnectedObserver = testScheduler.CreateObserver<bool>();
            sut.IsConnected.Subscribe(isConnectedObserver);
            void Change(bool isConnected) => connectivity.ConnectivityChanged +=
                Raise.Event<ConnectivityChangedEventHandler>(connectivity,
                    new ConnectivityChangedEventArgs { IsConnected = isConnected });
            testScheduler.Schedule(TimeSpan.FromTicks(3), () => Change(true));
            testScheduler.Schedule(TimeSpan.FromMilliseconds(251), () => Change(false));
            testScheduler.Schedule(TimeSpan.FromMilliseconds(501), () => Change(true));
            testScheduler.Schedule(TimeSpan.FromMilliseconds(751), () => Change(true));
            testScheduler.Schedule(TimeSpan.FromMilliseconds(752), () => Change(false));
            testScheduler.Schedule(TimeSpan.FromMilliseconds(753), () => Change(true));
            testScheduler.Schedule(TimeSpan.FromMilliseconds(754), () => Change(false));
            testScheduler.Schedule(TimeSpan.FromMilliseconds(1001), () => Change(true));
            testScheduler.Schedule(TimeSpan.FromMilliseconds(1002), () => Change(false));
            testScheduler.Start();
            isConnectedObserver.Messages.AssertEqual(
                OnNext(2, true),
                OnNext(TimeSpan.FromMilliseconds(251).Ticks + 1, false));
        }
    }
