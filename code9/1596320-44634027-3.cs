        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            var propItem = context.Instance as PropertyItem;
            if (propItem != null)
                return TypeDescriptor.GetConverter(propItem.PropertyDescription.Type).GetStandardValues(context);
            else
                return base.GetStandardValues(context);
        }
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            var propItem = context.Instance as PropertyItem;
            if (propItem != null)
                return TypeDescriptor.GetConverter(propItem.PropertyDescription.Type).GetStandardValuesSupported(context);
            else
                return base.GetStandardValuesSupported(context);
        }
