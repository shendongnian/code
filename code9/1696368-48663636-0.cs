     public class DeviceServiceTest: ReactiveTest {
                [TestMethod]
                public void ShouldReceiveOneDevice()
                {
                    var mockBleAdapter = new Mock<IAdapter>();
                    var deviceInteractionService = new DeviceInteractionService(mockBleAdapter.Object);
    
                    var scheduler = new TestScheduler();
                    var obs = scheduler.CreateColdObservable(OnNext(100, new MockScannedDevice())); // create an observable that will emit one value
    
    
                    mockBleAdapter.Setup(adapter => adapter.Scan(null))
                        .Returns(obs); // use Moq framework to return the observable created
                    // subscribe
                    deviceInteractionService.ScanDevices()
                            .Subscribe(res => Console.WriteLine("hello"));
    
                    // then start
                    scheduler.Start();
    
                }
       }
