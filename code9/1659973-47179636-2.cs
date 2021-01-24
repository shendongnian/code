    using System.Xml.Serialization;
    using System.IO;
    
    public static class SettingsIO
    {
      public static void WriteSettings(AppSettings settings, string settingsFilePath)
      {
        XmlSerializer serializer = new XmlSerializer(typeof(AppSettings));
        if (!Directory.Exists(Path.GetDirectoryName(settingsFilePath)))
          Directory.CreateDirectory(Path.GetDirectoryName(settingsFilePath));
        using (StreamWriter SW = new StreamWriter(settingsFilePath))
          serializer.Serialize(SW, settings);
      }
      public static AppSettings GetSettings(string settingsFilePath)
      {
        AppSettings m_Settings = null;
        if (File.Exists(settingsFilePath))
        {
          XmlSerializer serializer = new XmlSerializer(typeof(AppSettings));
          using (FileStream FS = new FileStream(settingsFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (StreamReader SR = new StreamReader(FS))
              m_Settings = (AppSettings)serializer.Deserialize(SR);
        }
        if (m_Settings == null)
          m_Settings = new AppSettings();
        return m_Settings;
      }
    }
