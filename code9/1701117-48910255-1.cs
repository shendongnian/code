    protected class XmlXsdResolver : XmlUrlResolver
    {
        public override object GetEntity(Uri absoluteUri, string role, Type ofObjectToReturn)
        {
            return base.GetEntity(absoluteUri, role, ofObjectToReturn);
        }
    }
