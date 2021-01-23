		internal override string GetXmlElementName()
		{
			if (!this.FolderName.HasValue)
			{
				return "FolderId";
			}
			return "DistinguishedFolderId";
		}
    	public FolderId(WellKnownFolderName folderName, Mailbox mailbox) : this(folderName)
		{
			this.mailbox = mailbox;
		}
		
        internal override void WriteAttributesToXml(EwsServiceXmlWriter writer)
		{
			if (this.FolderName.HasValue)
			{
				writer.WriteAttributeValue("Id", this.FolderName.Value.ToString().ToLowerInvariant());
				if (this.Mailbox != null)
				{
					this.Mailbox.WriteToXml(writer, "Mailbox");
					return;
				}
			}
			else
			{
				base.WriteAttributesToXml(writer);
			}
		}
		public override string ToString()
		{
			if (!this.IsValid)
			{
				return string.Empty;
			}
			if (!this.FolderName.HasValue)
			{
				return base.ToString();
			}
			if (this.Mailbox != null && this.mailbox.IsValid)
			{
				return string.Format("{0} ({1})", this.folderName.Value, this.Mailbox.ToString());
			}
			return this.FolderName.Value.ToString();
		}
