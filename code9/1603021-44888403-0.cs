    public Task<Response> RequestAsync(byte subnetID, byte deviceID, int deviceType, int operateCode, ref byte[] addtional, int expectedResponseCode, CancellationToken ct = default(CancellationToken)) {
        var tcs = new TaskCompletionSource<Response>();           
        DataArrivalHandler handler = null;
        handler = (byte sub, byte device, int type, int opCode, int length, ref byte[] additional) => {
            // got something, check if that is what we are waiting for
            if (opCode == expectedResponseCode) {
                DataArrival -= handler;
                // construct response here
                Response res = null; // = new Response(subnetID, deviceID, etc)
                tcs.TrySetResult(res);
            }
        };
        DataArrival += handler;
        // you can use cancellation for timeouts also
        ct.Register(() =>
        {
            DataArrival -= handler;
            tcs.TrySetCanceled(ct);
        });
        if (!Send_LAN(subnetID, deviceID, operateCode, ref addtional)) {
            DataArrival -= handler;                
            // throw here, or set exception on task completion source, or set result to null
            tcs.TrySetException(new Exception("Send_LAN returned false"));
        }
        return tcs.Task;
    }
    public class Response {
        public byte SubnetID { get; set; }
        // etc
    }
