            /// <summary>
        /// Replaces anchor hrefs to documents on server with embedded OLE objects 
        /// Start the parse processing
        /// </summary>
        /// <param name="html"></param>
        /// <param name="embeddServerLinksAsObjects"></param>
        /// <returns></returns>
        public IList<OpenXmlCompositeElement> Parse(string html, bool embeddServerLinksAsObjects)
        {
            try
            {
                if (embeddServerLinksAsObjects)
                {
                    html = ReplaceAnchorLinksByOXMLLinks(html, this.serverRoot);                 
                }
                IList<OpenXmlCompositeElement> oceList = base.Parse(html);
                if (embeddServerLinksAsObjects)
                {
                    oceList = ReplaceOXMLLinksByOLEObjects(oceList, this.mainDocumentPart, this.serverRoot);
                }
                return oceList;
            }
            catch (Exception ex)
            {
            }
            return null;
        }
