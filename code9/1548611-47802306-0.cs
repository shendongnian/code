	class FileEntry : IFile
	{
		private readonly String _fileName;
		private readonly Stream _content;
		private readonly String _type;
		private readonly DateTime _modified;
		
		public FileEntry(String fileName, String type, Stream content)
		{
			_fileName = fileName;
			_type = type;
			_content = content;
			_modified = DateTime.Now;
		}
		
		public Stream Body
		{
			get { return _content; }
		}
		
		public Boolean IsClosed
		{
			get { return _content.CanRead == false; }
		}
		
		public DateTime LastModified
		{
			get { return _modified; }
		}
		
		public Int32 Length
		{
			get
			{
				return (Int32)_content.Length;
			}
		}
		
		public String Name
		{
			get { return _fileName; }
		}
		
		public String Type
		{
			get { return _type; }
		}
		
		public void Close()
		{
			_content.Close();
		}
		
		public void Dispose()
		{
			_content.Dispose();
		}
		
		public IBlob Slice(Int32 start = 0, Int32 end = Int32.MaxValue, String contentType = null)
		{
			var ms = new MemoryStream();
			_content.Position = start;
			var buffer = new Byte[Math.Max(0, Math.Min(end, _content.Length) - start)];
			_content.Read(buffer, 0, buffer.Length);
			ms.Write(buffer, 0, buffer.Length);
			_content.Position = 0;
			return new FileEntry(_fileName, _type, ms);
		}
	}
