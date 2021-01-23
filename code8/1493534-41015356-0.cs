        private void Mavlink_PacketReceived(var pPacket)
        {
            if(pPacket != null)
			{
			    Console.WriteLine(pPacket.SystemId);
				Console.WriteLine(pPacket.ComponentId);
				Console.WriteLine(pPacket.SequenceNumber);
				Console.WriteLine(pPacket.TimeStamp);
				Console.WriteLine(pPacket.Message);
			}
        }
