    public class DTDAndSignatureResolver : XmlUrlResolver
	{
		private readonly Uri DTDUri;
		private readonly List<string> XmlExtensions = new List<string>() { ".xml" };
		private readonly List<string> DTDExtensions = new List<string>() { ".dtd", ".ent" };
		private ICredentials credentials;
		public DTDAndSignatureResolver(Uri DTDUri)
		{
			this.DTDUri = DTDUri;
		}
		public override ICredentials Credentials
		{
			set { credentials = value; }
		}
		public override object GetEntity(Uri absoluteUri, string role, Type ofObjectToReturn)
		{
			if (DTDExtensions.Any(e => absoluteUri.ToString().ToLower().EndsWith(e)) || XmlExtensions.Any(e => absoluteUri.ToString().ToLower().EndsWith(e)))
			{
				return base.GetEntity(absoluteUri, role, ofObjectToReturn); //For DTD/ENT/XML lookup
			}
			else
			{
				return base.GetEntity(DTDUri, null, ofObjectToReturn); //For signature image lookup
			}
		}
		public override Uri ResolveUri(Uri uri, string relativeUri)
		{
			return base.ResolveUri(DTDUri, relativeUri);
		}
	}
