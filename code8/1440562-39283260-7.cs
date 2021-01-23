        public virtual void ReadXml(System.Xml.XmlReader reader)
        {
            #region read properties of the matrix and assign storage
            int rows = Int32.Parse(reader.GetAttribute("Rows")); // Should really be using XmlConvert for this
            int cols = Int32.Parse(reader.GetAttribute("Cols"));
            int numberOfChannels = Int32.Parse(reader.GetAttribute("NumberOfChannels"));
            SerializationCompressionRatio = Int32.Parse(reader.GetAttribute("CompressionRatio"));
            AllocateData(rows, cols, numberOfChannels);
            #endregion
            #region decode the data from Xml and assign the value to the matrix
            if (!reader.IsEmptyElement)
            {
                using (var subReader = reader.ReadSubtree())
                {
                    // Using ReadSubtree guarantees we don't read past the end of the element in case the <Bytes> element
                    // is missing or extra unexpected elements are included.
                    if (subReader.ReadToFollowing("Bytes"))
                    {
                        int size = _sizeOfElement * ManagedArray.Length;
                        if (SerializationCompressionRatio == 0)
                        {
                            Byte[] bytes = new Byte[size];
                            subReader.ReadElementContentAsBase64(bytes, 0, bytes.Length);
                            Bytes = bytes;
                        }
                        else
                        {
                            int extraHeaderBytes = 20000;
                            Byte[] bytes = new Byte[size + extraHeaderBytes];
                            int countOfBytesRead = subReader.ReadElementContentAsBase64(bytes, 0, bytes.Length);
                            Array.Resize<Byte>(ref bytes, countOfBytesRead);
                            Bytes = bytes;
                        }
                    }
                }
            }
            // Consume the end of the wrapper element also.
            reader.Read();
            #endregion
        }
