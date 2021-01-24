    public class X509CertificateConverter : ExpandableObjectConverter
    {
        public override object ConvertTo(ITypeDescriptorContext context,
                             System.Globalization.CultureInfo culture,
                             object value, Type destType)
        {
            if (destType == typeof(string) && value is X509CertificateConfigurationElement)
            {
                X509CertificateConfigurationElement cert = (X509CertificateConfigurationElement)value;
                return "Certificate";
            }
            return base.ConvertTo(context, culture, value, destType);
        }
        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
        {
            if (value is X509CertificateConfigurationElement)
            {
                X509CertificateConfigurationElement cert = (X509CertificateConfigurationElement)value;
                PropertyDescriptorCollection allProps = TypeDescriptor.GetProperties(cert);
                PropertyDescriptor[] propertyDescriptor = new PropertyDescriptor[4];
                propertyDescriptor[0] = allProps["FindValue"];
                propertyDescriptor[1] = allProps["StoreLocation"];
                propertyDescriptor[2] = allProps["StoreName"];
                propertyDescriptor[3] = allProps["X509FindType"];
                return new PropertyDescriptorCollection(propertyDescriptor);
            }
            return base.GetProperties(context, value, attributes);
        }
    }
