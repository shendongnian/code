    public override string SaveObjectToFile(string folder, string file, object o)
            {
                string filename = Path.Combine(folder, string.Format("{0}{1}", file, FileExtension));
                try
                {
                    using (StreamWriter writer = new StreamWriter(filename, append: false))
                    {
                        new XmlSerializer(o.GetType()).Serialize(writer, o);
                        writer.Close();
                    }
                }
                catch (Exception ex)
                {
                    Trace.TraceError("Unable to serialize object " + ex.Message);
                }
    
                return filename;
            }
