    public class UseXmlSerializerAttribute : Attribute, IControllerConfiguration
    {
        public void Initialize(HttpControllerSettings controllerSettings,
                               HttpControllerDescriptor controllerDescriptor)
        {
            var xmlFormater = new XmlMediaTypeFormatter {UseXmlSerializer = true};
    
            controllerSettings.Formatters.Clear();
            controllerSettings.Formatters.Add(xmlFormater);
        }
    }
