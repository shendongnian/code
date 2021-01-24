    [TestClass]
    public class DeviceTests {
        [TestMethod]
        public void _ValueChangedEventDataParsingTest() {
            //Arrange
            var message = "message";
            var expected = "expected";
            var device = new FakeBluetoothLEDevice(message, expected);
            var sut = new MyDevice(device);
            //Act
            device.InvokeValueChanged(message);
            //Assert
            Assert.AreEqual(expected, sut.SomeProperty);
        }
        public interface IBlueToothService {
            Action<string> ValueChangedHandler { get; set; }
        }
        public class FakeBluetoothLEDevice : IBlueToothService {
            private string message;
            private string parsed;
            public FakeBluetoothLEDevice(string message, string expected) {
                this.message = message;
                this.parsed = expected;
            }
            public Action<string> ValueChangedHandler { get; set; }
            public void InvokeValueChanged(string p) {
                var handler = ValueChangedHandler ?? delegate { };
                if (p == message) {
                    ValueChangedHandler(parsed);
                }
            }
        }
        public class MyDevice {
            private IBlueToothService device;
            public string SomeProperty { get; set; }
            public MyDevice(IBlueToothService device) {
                this.device = device;
                device.ValueChangedHandler = handler;
            }
            private void handler(string parsedValue) {
                SomeProperty = parsedValue;
            }
        }
    }
