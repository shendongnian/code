     byte[] buf = await serialPort.ReadAsync();
---
    
    static public class SerialPortExtensions
    {
        public static Task<byte[]> ReadAsync(this SerialPort serialPort)
        {
            var tcs = new TaskCompletionSource<byte[]>();
            SerialDataReceivedEventHandler dataReceived = null;
            dataReceived = (s, e) =>
            {
                serialPort.DataReceived -= dataReceived;
                var buf = new byte[serialPort.BytesToRead];
                serialPort.Read(buf, 0, buf.Length);
                tcs.TrySetResult(buf);
            };
            serialPort.DataReceived += dataReceived;
            return tcs.Task;
        }
    }
