	public static MemoryStream DecryptFile(string xmlFullPath, DateTime encryptionKey) {
		var elemToLook = "number";
		var inElem = false;
		var number = "";
		var memoryStream = new MemoryStream();
		using (var writer = XmlWriter.Create(memoryStream))
		using (var reader = XmlReader.Create(xmlFullPath)) {
			while (reader.Read()) {
				switch (reader.NodeType) {
					case XmlNodeType.Element:
						if (reader.Name == elemToLook)
							inElem = true;
						writer.WriteStartElement(reader.Name);
						break;
					case XmlNodeType.Text:
						if (inElem) {
							number = reader.Value;
							// TODO: This is where your decryption code will go.
							number = $"decrypted({number})"; 
                            writer.WriteString(number);
						} else
							writer.WriteString(reader.Value);
						break;
					case XmlNodeType.XmlDeclaration:
					case XmlNodeType.ProcessingInstruction:
						writer.WriteProcessingInstruction(reader.Name, reader.Value);
						break;
					case XmlNodeType.Comment:
						writer.WriteComment(reader.Value);
						break;
					case XmlNodeType.EndElement:
						if (inElem)
							inElem = false;
						writer.WriteFullEndElement();
						break;
					case XmlNodeType.Whitespace:
						writer.WriteRaw(reader.Value);
						break;
				}
			}
		}
		memoryStream.Position = 0;
		return memoryStream;
	}
