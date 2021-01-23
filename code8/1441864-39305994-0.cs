    using System.IO;
    using System.Net.Sockets;
    
    namespace XnaCommonLib.Network
    {
        public static class HelperMethods
        {
            public static void Receive(TcpClient connection, BinaryReader reader, PacketProtocol packetProtocol)
            {
                var bufferSize = connection.Available;
                var buffer = reader.ReadBytes(bufferSize);
                packetProtocol.DataReceived(buffer); 
            }
        }
    }
