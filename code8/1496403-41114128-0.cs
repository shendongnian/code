        /// <summary>
        /// Output this <see cref="XElement"/> to an <see cref="XmlWriter"/>.
        /// </summary>
        /// <param name="writer">
        /// The <see cref="XmlWriter"/> to output the XML to.
        /// </param>
        public void Save(XmlWriter writer) {
            if (writer == null) throw new ArgumentNullException("writer");
            writer.WriteStartDocument();
            WriteTo(writer);
            writer.WriteEndDocument();
        }
