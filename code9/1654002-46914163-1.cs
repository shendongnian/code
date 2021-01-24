    using System;
    using System.IO;
    using System.Messaging;
    using System.Runtime.InteropServices;
    namespace StructToBytes
    {
        // 4 bytes
        [Serializable]
        [StructLayout(LayoutKind.Explicit)]
        public unsafe struct DiObject
        {
            [FieldOffset(0)]
            public byte Command;
            [FieldOffset(1)]
            public byte ErrorClass;
            [FieldOffset(2)]
            public byte Reserved;
            [FieldOffset(3)]
            public byte Flags;
        }
        // 8 + (numDi*4) bytes
        [Serializable]
        public unsafe struct MyPacket
        {
            public uint ProtocolIdentifier;
            public uint NumDi;
            public fixed byte Di[2 * 4];
        }
        internal unsafe class Program
        {
            private static byte[] GetBytes(MyPacket packet, int packetSize)
            {
                var data = new byte[packetSize];
                var ptr = Marshal.AllocHGlobal(packetSize);
                // ==== Access violation exception occurs here ====
                Marshal.StructureToPtr(packet, ptr, true);
                Marshal.Copy(ptr, data, 0, packetSize);
                Marshal.FreeHGlobal(ptr);
                return data;
            }
            private static MyPacket FromBytes(byte[] data)
            {
                var packet = new MyPacket();
                var dataSize = Marshal.SizeOf(packet);
                var ptr = Marshal.AllocHGlobal(dataSize);
                Marshal.Copy(data, 0, ptr, dataSize);
                packet = (MyPacket)Marshal.PtrToStructure(ptr, packet.GetType());
                Marshal.FreeHGlobal(ptr);
                return packet;
            }
            private static void Main(string[] args)
            {
                const string queuePath = @".\private$\test_msmq";
                // Create the packet
                var packet = new MyPacket();
                // 8 bytes
                packet.ProtocolIdentifier = 1;
                packet.NumDi = 2;
                // 8 bytes
                // packet.Di = new DiObject[packet.NumDi];
                packet.Di[0] = 2;
                packet.Di[1] = 3;
                packet.Di[2] = 4;
                packet.Di[3] = 5;
                packet.Di[4] = 6;
                packet.Di[5] = 7;
                packet.Di[6] = 8;
                packet.Di[7] = 9;
                // Convert the struct in bytes
                int packetSize = Marshal.SizeOf<MyPacket>();
                var packetBytes = GetBytes(packet, packetSize);
                // Create the message
                var msg = new Message();
                msg.BodyStream = new MemoryStream(packetBytes);
                // Open or create the message queue
                if (!MessageQueue.Exists(queuePath))
                    MessageQueue.Create(queuePath);
                // Open the queue
                var q = new MessageQueue(queuePath); // {Formatter = new BinaryMessageFormatter()};
                // Send the message to the queue
                q.Send(msg);
            }
        }
    }
