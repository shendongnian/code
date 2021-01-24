    namespace PingManyDevices {
    
        public class DeviceChecker {                
    
            public async Task<PingReply[]> CheckAllDevices(IEnumerable<IPAddress> devices) {
                var pings = devices.Select(address => new Ping().SendPingAsync(address, 5000));
                return await Task.WhenAll(pings);
            }
            /***
            * Maybe push it a little further
            ***/ 
            public async Task<PingReply[]> CheckAllDevices(IEnumerable<IPAddress> devices) {
                var pings = devices.AsParallel().Select(address => new Ping().SendPingAsync(address, 5000));
                return await Task.WhenAll(pings);
            }          
        }
    } 
