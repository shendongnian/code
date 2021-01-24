	public class EmbeddedVirtualFile : VirtualFile
	{
		private Stream _stream;
		public EmbeddedVirtualFile(string virtualPath,
			Stream stream) : base(virtualPath)
		{
			if (null == stream)
				throw new ArgumentNullException("stream");
			_stream = stream;
		}
		public override Stream Open()
		{
			return _stream;
		}
	}
