    /// <summary>
        /// Provides utility methods for manipulations with media files.
        /// </summary>
        public static class MediaHelper
        {
            /// <summary>
            /// Gets the media URL by id.
            /// </summary>
            /// <param name="mediaId">The media id.</param>
            /// <returns>Returns image url.</returns>
            public static string GetMediaUrlById(int mediaId)
            {
                string retVal = String.Empty;
                try
                {
                    XPathNodeIterator xpathNodeIterator = umbraco.library.GetMedia(mediaId, false);
                    if (xpathNodeIterator != null && mediaId != 0)
                    {
                        xpathNodeIterator.MoveNext();
                        var selectSingleNode = xpathNodeIterator.Current.SelectSingleNode("umbracoFile");
                        if (selectSingleNode != null)
                            retVal = selectSingleNode.Value;
                    }
                }
                catch
                {
                }
    
                return retVal;
            }
    
    // Some more methods..
    
    }
