        public override void WriteStartDocument() {
            StartDocument(-1);
        }
 
        // Writes out the XML declaration with the version "1.0" and the standalone attribute.
        public override void WriteStartDocument(bool standalone) {
            StartDocument(standalone ? 1 : 0);
        }
        void StartDocument(int standalone) {
            try {
                if (this.currentState != State.Start) {
                    throw new InvalidOperationException(Res.GetString(Res.Xml_NotTheFirst));
                }
                this.stateTable = stateTableDocument;
                this.currentState = State.Prolog;
 
                StringBuilder bufBld = new StringBuilder(128);
                bufBld.Append("version=" + quoteChar + "1.0" + quoteChar);
                if (this.encoding != null) {
                    bufBld.Append(" encoding=");
                    bufBld.Append(quoteChar);
                    bufBld.Append(this.encoding.WebName);
                    bufBld.Append(quoteChar);
                }
                if (standalone >= 0) {
                    bufBld.Append(" standalone=");
                    bufBld.Append(quoteChar);
                    bufBld.Append(standalone == 0 ? "no" : "yes");
                    bufBld.Append(quoteChar);
                }
                InternalWriteProcessingInstruction("xml", bufBld.ToString());
            }
            catch {
                currentState = State.Error;
                throw;
            }
        }
        void InternalWriteProcessingInstruction(string name, string text) {
            textWriter.Write("<?");
            ValidateName(name, false);
            textWriter.Write(name);
            textWriter.Write(' ');
            if (null != text) {
                xmlEncoder.WriteRawWithSurrogateChecking(text);
            }
            textWriter.Write("?>");
        }
