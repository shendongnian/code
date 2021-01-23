        dsRelease _Data = null; // Dataset.
        private void Load_Data()
        {
            StreamReader sr;
            XmlReader reader;
            _Data = new dsRelease(); //new dataset
            sr = new StreamReader(_SavePath, Encoding.UTF8);
            reader = new XmlTextReader(sr);
            _Data.ReadXml(reader, XmlReadMode.ReadSchema);
                    
            if (reader != null) reader.Close();
            if (sr != null) sr.Close();
        }
        public void Save_Data(string savepath)
        {
            XmlTextWriter writer = null;
            writer = new XmlTextWriter(savepath, Encoding.UTF8);
			//Write Dataset.
            _Data.WriteXml(writer, XmlWriteMode.WriteSchema);
        }
