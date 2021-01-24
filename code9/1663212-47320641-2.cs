            byte[] CreatePacket(string s, Operation op)
            {
                var packet = new List<byte>();
                packet.AddRange(BitConverter.GetBytes((UInt16) 0x1092));
                packet.Add(1);
                var data = Encoding.ASCII.GetBytes(s);
                packet.AddRange(BitConverter.GetBytes((UInt32) (9 + data.Length)));
                packet.Add((byte) (op == Operation.Encode ? 1 : 2));
                packet.AddRange(data);
                packet.Add(CheckSum(packet));
                return packet.ToArray();
            }
