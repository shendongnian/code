     /// <summary>
    /// Serializable version of StrokeCollection allowing for base64 saving using XMLSerializer
    /// </summary>
    [Serializable]
    public class StrokeCollectionEx : StrokeCollection, IXmlSerializable
    {
        public StrokeCollectionEx() { }
        #region " ReadXml "
        /// <summary>
        /// ReadXml
        /// </summary>
        /// <param name="reader"></param>
        public void ReadXml(XmlReader reader)
        {
            string s = reader.ReadElementContentAsString();
            byte[] strokeBits = Convert.FromBase64String(s);
            if (strokeBits != null && strokeBits.Length > 0)
            {
                using (MemoryStream ms = new MemoryStream(strokeBits))
                {
                    //Reload this from stream
                    this.Clear();
                    StrokeCollection sc = new StrokeCollection(ms);
                    foreach (Stroke x in sc)
                    {
                        this.Add(x);
                    }
                }
            }
        }
        #endregion
        #region " WriteXml "
        /// <summary>
        /// WriteXml
        /// </summary>
        /// <param name="writer"></param>
        public void WriteXml(XmlWriter writer)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                Save(ms);
                byte[] strokeBits = ms.ToArray();
                writer.WriteBase64(strokeBits, 0, strokeBits.Length);
            }
        }
        #endregion
        #region " GetSchema "
        /// <summary>
        /// GetSchema
        /// </summary>
        /// <returns></returns>
        public XmlSchema GetSchema()
        {
            return null;
        }
        #endregion
    }
