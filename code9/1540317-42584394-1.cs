	public sealed class StringWriterWithEncoding : StringWriter
	{
		private readonly Encoding encoding;
		
		public StringWriterWithEncoding() : this(Encoding.UTF8) { }
		public StringWriterWithEncoding(Encoding encoding)
		{
			this.encoding = encoding;
		}
		
		public override Encoding Encoding
		{
			get { return encoding; }
		}
	}
