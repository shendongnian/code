            public static bool Verify(XmlDocument document, X509Certificate2 certificate)
        {
            // Check arguments.
            if (document == null)
                throw new ArgumentException("Doc");
            if (certificate == null)
                throw new ArgumentException("Key");
            // Create a new SignedXml object and pass it
            // the XML document class.
            var signedXml = new SignedXml(document);
            // Find the "Signature" node and create a new
            // XmlNodeList object.
            var nodeList = document.GetElementsByTagName("Signature");
            // Throw an exception if no signature was found.
            if (nodeList.Count <= 0)
            {
                throw new CryptographicException("Verification failed: No Signature was found in the document.");
            }
            // This example only supports one signature for
            // the entire XML document.  Throw an exception 
            // if more than one signature was found.
            if (nodeList.Count >= 2)
            {
                throw new CryptographicException("Verification failed: More that one signature was found for the document.");
            }
            // Load the first <signature> node.  
            signedXml.LoadXml((XmlElement)nodeList[0]);
            return signedXml.CheckSignature(certificate, true);
        }
