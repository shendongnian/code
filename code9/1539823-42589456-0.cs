    namespace PingManyDevices {
    
        public class DeviceChecker {                
    
            public async Task<PingReply[]> CheckAllDevices(IEnumerable<IPAddress> devices) {
                var pings = devices.Select(address => new Ping().SendPingAsync(address, 5000));
                return await Task.WhenAll(pings);
            }
            
            //Setup for demo
            public async void CheckAllDevicesCommand() {
                var devices = Enumerable.Range(0, 1000000).Select(_ => GetRandomIP()).ToArray();
                await CheckAllDevices(devices);
            }
    
            private static Random random = new Random();
    
            private IPAddress GetRandomIP() {
                return IPAddress.Parse($"{GetRndByte()}.{GetRndByte()}.{GetRndByte()}.{GetRndByte()}";
            }
    
            private byte GetRndByte() {
                return (byte)random.Next(1, 254);
            }
        }
    } 
