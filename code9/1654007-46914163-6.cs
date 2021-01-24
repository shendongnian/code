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
        [Serializable]
        public unsafe struct MyPacket
        {
            public uint ProtocolIdentifier;
            public uint NumDi;
            public DiObject[] Di;
            public byte[] ToBytes()
            {
                byte[] buffer = new byte[NumDi];
                fixed(DiObject* pDi = Di)
                fixed(byte* pBuff = buffer)
                {
                    var pBuffDi = (DiObject*)pBuff;
                    var pDiPtr = pDi;
                    for (int i = 0; i < NumDi; i++)
                        *pBuffDi++ = *pDiPtr++;
                }
                return buffer;
            }
        }
        internal unsafe class Program
        {
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
                packet.NumDi = 5;
                // 8 bytes
                packet.Di = new DiObject[packet.NumDi];
                packet.Di[0].Command = 2;
                packet.Di[0].ErrorClass = 3;
                packet.Di[0].Flags = 4;
                packet.Di[0].Reserved = 5;
                packet.Di[1].Command = 6;
                packet.Di[1].ErrorClass = 7;
                packet.Di[1].Flags = 8;
                packet.Di[1].Reserved = 9;
                packet.Di[2].Command = 6;
                packet.Di[2].ErrorClass = 7;
                packet.Di[2].Flags = 8;
                packet.Di[2].Reserved = 9;
                packet.Di[3].Command = 6;
                packet.Di[3].ErrorClass = 7;
                packet.Di[3].Flags = 8;
                packet.Di[3].Reserved = 9;
                // Create the message
                var msg = new Message();
                msg.BodyStream = new MemoryStream(packet.ToBytes());
                // Open or create the message queue
                if (!MessageQueue.Exists(queuePath))
                    MessageQueue.Create(queuePath);
                // Open the queue
                var q = new MessageQueue(queuePath);
                // Send the message to the queue
                q.Send(msg);
            }
        }
    }
