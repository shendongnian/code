    public class MemoryMappedHandler
	{
		MemoryMappedFile mmf = MemoryMappedFile.CreateOrOpen("mmf1", 512);
		MemoryMappedViewStream stream;
        MemoryMappedViewAccessor accessor;
		BinaryReader reader;
		public static Message message = new Message();
		public MemoryMappedHandler()
		{
			stream = mmf.CreateViewStream();
            accessor = mmf.CreateViewAccessor();
			reader = new BinaryReader(stream);
			new Thread(() =>
			{
				while (stream.CanRead)
				{
					Thread.Sleep(500);
					message.MyStringWithEvent = reader.ReadString();
                    accessor.Write(0, 0);
					stream.Position = 0;
				}
			}).Start();
		}
		public static void PassMessage(string message)
		{
			try
			{
				using (MemoryMappedFile mmf = MemoryMappedFile.OpenExisting("mmf1"))
				{
					using (MemoryMappedViewStream stream = mmf.CreateViewStream(0, 512))
					{
						BinaryWriter writer = new BinaryWriter(stream);
						writer.Write(message);
					}
				}
			}
			catch (FileNotFoundException)
			{
				MessageBox.Show("Cannot Send a Message. Please open Main.exe");
			}
		}
	}
