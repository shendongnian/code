        public MemoryStream ReadStreamBinary(Stream stream, int bufferSize)
        {
			var ms = new MemoryStream();
			var buffer = CreateBuffer(bufferSize);
			var finished = false;
			while (!finished)
			{
				buffer.Initialize();
				var bytes = stream.Read(buffer, 0, buffer.Length);
				if (bytes > 0)
				{
					ms.Write(buffer, 0, bytes);
				}
				else
				{
					finished = true;
				}
			}
			
			ms.Seek(0, SeekOrigin.Begin);
			return ms;
        }
