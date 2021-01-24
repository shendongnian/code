    using System.IO;
    using System.Xml.Serialization;
    public void LoadConfig<T>()
    {
      if (File.Exists(_sConfigFileName))
      {
        var  srReader = File.OpenText(_sConfigFileName);
        var  xsSerializer = new XmlSerializer(typeof(T));
        var  oData = xsSerializer.Deserialize(srReader);
        m_oObj = (T)oData;
        srReader.Close();
      }
    }
