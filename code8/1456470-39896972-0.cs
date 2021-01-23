    public class NameValueFileProtectedSectionHandler : IConfigurationSectionHandler
    {
        public object Create(object parent, object configContext, XmlNode section)
        {
            object result = parent;
            XmlNode fileAttribute = section.Attributes.RemoveNamedItem("file");
            
            if (fileAttribute == null && fileAttribute.Value.Length == 0)
            {
                return new NameValueSectionHandler().Create(result, null, section);
            }
            IConfigErrorInfo configXmlNode = fileAttribute as IConfigErrorInfo;
            if (configXmlNode == null)
            {
                return null;
            }
            
            string directory = Path.GetDirectoryName(configXmlNode.Filename);
            string absoluteFilePath = Path.GetFullPath(directory + fileAttribute.Value);
            if (!File.Exists(absoluteFilePath))
            {
                throw new ConfigurationErrorsException(string.Format("external config file: {0} does not exists", absoluteFilePath));
            }
            var configXmlDocument = new ConfigXmlDocument();
            try
            {
                configXmlDocument.Load(absoluteFilePath);
            }
            catch (XmlException e)
            {
                throw new ConfigurationErrorsException(e.Message, e, absoluteFilePath, e.LineNumber);
            }
            if (section.Name != configXmlDocument.DocumentElement.Name)
            {
                throw new ConfigurationErrorsException(string.Format("Section name '{0}' in app.config does not match section name '{1}' in file '{2}'", section.Name, configXmlDocument.DocumentElement.Name, absoluteFilePath));
            }
            
            var nodeToDecrypt = configXmlDocument.DocumentElement["EncryptedData"];
            if (nodeToDecrypt == null)
            {
                throw new ConfigurationErrorsException(string.Format("External encrypted file {0} does not contain EncryptedData element", absoluteFilePath));
            }
            var protectionProvider = new DpapiProtectedConfigurationProvider();
            var decryptedConfigSection = protectionProvider.Decrypt(nodeToDecrypt);
            result = new NameValueSectionHandler().Create(result, null, decryptedConfigSection);
            
            return result;
        }
    }
