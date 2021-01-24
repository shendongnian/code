        /// <summary>
        /// Get [maxAllowedContentLength] from web.config
        /// </summary>
        internal static long GetMaxAllowedContentLengthBytes()
        {
            const long DefaultAllowedContentLengthBytes = 30000000;
            using (System.IO.StreamReader reader = new System.IO.StreamReader(System.Web.HttpRuntime.AppDomainAppPath + "/web.config"))
            {
                System.Xml.XmlDocument xmlDocument = new System.Xml.XmlDocument();
                xmlDocument.LoadXml(reader.ReadToEnd());
                 if (xmlDocument.GetElementsByTagName("requestLimits").Count > 0)
                {
                    var maxAllowedContentLength = xmlDocument.GetElementsByTagName("requestLimits")[0].Attributes.Cast<System.Xml.XmlAttribute>().FirstOrDefault(atributo => atributo.Name.Equals("maxAllowedContentLength"));
                    return Convert.ToInt64(maxAllowedContentLength.Value);
                }
                else
                    return DefaultAllowedContentLengthBytes;
            }
        }
        /// <summary>
        /// Get [MaxRequestLength] from web.config
        /// </summary>
        internal static long GetMaxRequestLengthBytes()
        {
            return (HttpContext.Current.GetSection("system.web/httpRuntime") as System.Web.Configuration.HttpRuntimeSection).MaxRequestLength * 1024;
        }
