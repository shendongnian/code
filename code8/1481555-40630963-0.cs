    using System;
    using System.Net;
    using System.Net.Sockets;
    using System.Threading.Tasks;
    namespace Demo
    {
        class Program
        {
            static void Main()
            {
                Console.WriteLine(GetTime().Result);
            }
            public static async Task<DateTime> GetTime()
            {
                return await Task.WhenAny
                (
                    Task.Run(() => GetNetworkTime("time.windows.com")),
                    Task.Run(() => GetNetworkTime("1.uk.pool.ntp.org")),
                    Task.Run(() => GetNetworkTime("time.nist.gov"))
                ).Result;
            }
            public static async Task<DateTime> GetNetworkTime(string ntpServer)
            {
                IPAddress[] address = Dns.GetHostEntry(ntpServer).AddressList;
                if (address == null || address.Length == 0)
                    throw new ArgumentException("Could not resolve ip address from '" + ntpServer + "'.", nameof(ntpServer));
                IPEndPoint ep = new IPEndPoint(address[0], 123);
                var result = await GetNetworkTime(ep);
                return result;
            }
            public static async Task<DateTime> GetNetworkTime(IPEndPoint ep)
            {
                using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp))
                {
                    await Task.Factory.FromAsync(socket.BeginConnect, socket.EndConnect, ep, null);
                    byte[] ntpData = new byte[48]; // RFC 2030 
                    ntpData[0] = 0x1B;
                    await Task.Factory.FromAsync(
                        socket.BeginSend(ntpData, 0, ntpData.Length, SocketFlags.None, null, null),
                        socket.EndSend);
                    await Task.Factory.FromAsync(
                        socket.BeginReceive(ntpData, 0, ntpData.Length, SocketFlags.None, null, null),
                        socket.EndReceive);
                    return asDateTime(ntpData);
                }
            }
            static DateTime asDateTime(byte[] ntpData)
            {
                byte offsetTransmitTime = 40;
                ulong intpart = 0;
                ulong fractpart = 0;
                for (int i = 0; i <= 3; i++)
                    intpart = 256*intpart + ntpData[offsetTransmitTime + i];
                for (int i = 4; i <= 7; i++)
                    fractpart = 256*fractpart + ntpData[offsetTransmitTime + i];
                ulong milliseconds = (intpart*1000 + (fractpart*1000)/0x100000000L);
                TimeSpan timeSpan = TimeSpan.FromTicks((long) milliseconds*TimeSpan.TicksPerMillisecond);
                DateTime dateTime = new DateTime(1900, 1, 1);
                dateTime += timeSpan;
                TimeSpan offsetAmount = TimeZone.CurrentTimeZone.GetUtcOffset(dateTime);
                DateTime networkDateTime = (dateTime + offsetAmount);
                return networkDateTime;
            }
        }
    }
