        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
        {
            var propItem = context.Instance as PropertyItem;
            if (propItem != null)
                return TypeDescriptor.GetConverter(propItem.PropertyDescription.Type).GetProperties(context, value, attributes);
            else
                return base.GetProperties(context, value, attributes);
        }
        public override bool GetPropertiesSupported(ITypeDescriptorContext context)
        {
            var propItem = context.Instance as PropertyItem;
            if (propItem != null)
                return TypeDescriptor.GetConverter(propItem.PropertyDescription.Type).GetPropertiesSupported(context);
            return base.GetPropertiesSupported(context);
        }
