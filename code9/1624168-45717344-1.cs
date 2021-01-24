        /// <summary>
        ///   Opens an existing workbook from a stream.
        /// </summary>
        /// <param name = "stream">The stream to open.</param>
        public XLWorkbook(Stream stream):this(stream, XLEventTracking.Enabled)
        {
        }
