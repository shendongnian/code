    public void createPDF(...) {
       ...
       xmlToPdfInfo.Resolver = new XmlResourceResolver(...);
       xmlToPdfInfo.XslPath = getPathToMyStyleSheet();
       xmlToPdfInfo.IncludedDocsList = GetIncludedDocsList();
       Utils.XmlToPdf(xmlToPdfInfo, outputStream);
    }
    protected SortedList GetIncludedDocsList()
    {
        SortedList sortedList = new SortedList();
        sortedList.Add("headerFooter.xsl", BasePath() + ".common.headerFooter.xsl");
        ...
        return sortedList;
    }
-----
    public class Utils
    {
        private static XmlResourceResolver resolver;
        private static SortedList includedDocsList;
        /// <summary>Gets a PDF as stream from an xml-file, rendered by an xsl stylesheet</summary>
        /// <param name="xmlToPdfInfo">Contains all input information</param>
        /// <param name="outputStream">resulting PDF as a stream</param>
        public static void XmlToPdf(XmlToPdfInfo xmlToPdfInfo, OutputStream outputStream)
        {
            resolver = xmlToPdfInfo.Resolver;
            includedDocsList = xmlToPdfInfo.IncludedDocsList;
            ...
        }
        public class VgUriResolver : URIResolver
        {
            /// <summary>Gets the embedded file for the UriResolver</summary>
            /// <param name="href">relative path to the file (the path that has been put in <xsl:include>)</param>
            /// <param name="baseUri">base path</param>
            /// <returns>The embedded source </returns>
            public Source resolve(String href, String baseUri)
            {
                if (includedDocsList != null)
                {
                    IList keys = includedDocsList.GetKeyList();
                    String hrefFilename = Path.GetFileName(href);
                    foreach (var key in keys)
                    {
                        String pfad = (string) includedDocsList[key];
                        String filename = (String) key;
                        try
                        {
                            // "hard-match": if by chance we can get the file
                            // by the real resource path.
                            if (pfad.Equals(href))
                            {
                                byte[] bArr = ReadToEnd(resolver.GetManifestResourceStream(pfad));
                                return new StreamSource(new ByteArrayInputStream(bArr));
                            }
                            // "soft-match": looks for the filenames without any path. 
                            // Attention: works only fine if you **don't** have to include files
                            // with same name (different path)                          
                            if (filename.Equals(hrefFilename))
                            {
                                byte[] bArr = ReadToEnd(resolver.GetManifestResourceStream(pfad));
                                return new StreamSource(new ByteArrayInputStream(bArr));
                            }
                        }
                        catch (Exception)
                        {
                            try
                            {
                                return readFromFileStream(href);
                            }
                            catch (Exception)
                            {
                                return readFromFileStream(hrefFilename);
                            }
                        }
                    }                 
                }
                return new StreamSource(new StringReader(href));
            }
        }
    }
