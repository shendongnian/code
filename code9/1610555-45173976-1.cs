		public class DataMessage : Message
		{
			private readonly MessageHeaders _headers;
			private readonly MessageProperties _properties;
			public DataMessage()
			{
				this._headers = new MessageHeaders(MessageVersion.None);
				this._properties = new MessageProperties();
			}
			public override MessageHeaders Headers
			{
				get { return this._headers; }
			}
			public override MessageProperties Properties
			{
				get { return this._properties; }
			}
			public override MessageVersion Version
			{
				get { return this._headers.MessageVersion; }
			}
			protected override void OnWriteBodyContents( XmlDictionaryWriter writer )
			{
				writer.WriteStartElement("HTML");
				writer.WriteStartElement("HEAD");
				writer.WriteStartElement("BODY");
				writer.WriteStartElement("SPAN");
				writer.WriteString("This is a test page.");
				writer.WriteEndElement();
				writer.WriteEndElement();
				writer.WriteEndElement();
				writer.WriteEndElement();
			}
		}
