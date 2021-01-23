    private class MyXmlUrlResolver : XmlUrlResolver
        {
            private const string basePad = "MyNamespace.mysubnamespace.";
            public override object GetEntity(Uri absoluteUri, string role, Type ofObjectToReturn)
            {
                switch (absoluteUri.Scheme)
                {
                    case "file":
                        {
                            string origString = absoluteUri.OriginalString;
                            Assembly assembly = Assembly.GetExecutingAssembly();
                            // the filename starts after the last \
                            int index = origString.LastIndexOf('\\');                            
                            string filename = origString.Substring(index + 1);
                            string resourceName = basePad + filename;
                            var stream = assembly.GetManifestResourceStream(resourceName);
                            return stream;
                        }
                    default:
                        {
                            return (Stream)base.GetEntity(absoluteUri, role, ofObjectToReturn);
                        }
                }
            }
        }
