    public static class ImageUtils
    {
        /// <summary>
        /// Captures all or part of the raw png metadata.
        /// Can use this to capture PhonoBooth metadata by setting the filter to "iTXt"
        /// 
        /// throws: ArgumentException if not a png file
        /// </summary>
        /// <param name="imageFilePath"></param>
        /// <param name="itemMap"></param>
        /// <param name="filter"> optional filter on the key (contains)</param>
        /// <returns>true if successful, false otherwise.</returns>
        public static bool GetMetaDataItems(string imageFilePath, ref Dictionary<string, string> itemMap, string filter=null)
        {
            Assertion<ArgumentException>(imageFilePath.ToLower().EndsWith(".png"), "Expected png file");
            var ret = false;
            var query = string.Empty;
            itemMap.Clear();
            try
            {
                using (Stream fileStream = File.Open(imageFilePath, FileMode.Open))
                {
                    var decoder = BitmapDecoder.Create(fileStream, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.None);
                    GetMetaDataItems(decoder.Frames[0].Metadata as BitmapMetadata, ref itemMap, filter);
                }
                ret = true;
            }
            catch (Exception e)
            {
                ret = false;
                LogE(e.Message);
            }
            return ret;
        }
        /// <summary>
        /// Used to get the meta data from png file metadata
        /// Can use this to capture PhonoBooth metadata by setting the filter to "iTXt"
        /// </summary>
        /// <param name="bitmapMetadata"></param>
        /// <param name="itemMap"></param>
        /// <param name="filter">set this to iTXt for Phenosuite image data</param>
        /// <param name="query">initally null, used in recursive calls to get the child data</param>
        public static void GetMetaDataItems(BitmapMetadata bitmapMetadata , ref Dictionary<string, string> itemMap, string filter= null, string query = null )
        {
            if (query == null)
                query = string.Empty;
            if (bitmapMetadata != null)
            {
                var key = string.Empty;
                foreach (string relativeQuery in bitmapMetadata)
                {
                    var fullQuery = query + relativeQuery;
                    // GetQuery returns an object: either a string or child metadata
                    // If a string then it is one of 4 values: ["Keyword", "Translated", "Compression", "Language Tag", "TextEntry"]
                    // We want the Keyword and the subsequent TextEntry items, the tags are a sequence in the order specified above
                    var metadata = bitmapMetadata.GetQuery(relativeQuery);
                    var innerBitmapMetadata = metadata as BitmapMetadata;
                    if (innerBitmapMetadata == null)
                        AddToMap(ref key, fullQuery, metadata?.ToString(), ref itemMap, filter);	// Not a metadata structure so it is data - therefore check and Add to map
                    else
                        GetMetaDataItems(innerBitmapMetadata, ref itemMap, filter, fullQuery);		// Recursive call
                }
            }
        }
        /// <summary>
        /// Suitable for Png iTXt metadata
        /// This is used to buld the item map from the metadata
        /// </summary>
        /// <param name="key">key like "Application" or "Lighting Mode"</param>
        /// <param name="fullQuery">metadata query</param>
        /// <param name="metadata">image metadata</param>
        /// <param name="itemMap">map being populated from the metadata</param>
        /// <param name="filter">we dont want all the meta data - so this filters on the "sub folder" of the meta data -Phenosuite uses "iTXt"  </param>
        private static void AddToMap(ref string key, string fullQuery, string metadata, ref Dictionary<string, string> itemMap, string filter)
        {
            if (metadata != null)
            {
                if (!fullQuery.Contains("Translated"))
                {
                    if ((filter == null) || ((fullQuery.Contains(filter))))
                    {
                        if (fullQuery.Contains("Keyword"))
                            key = metadata;
                        if (fullQuery.Contains("TextEntry") && (key != null))
                            itemMap[key] = metadata?.ToString();
                    }
                }
            }
        }
    }
