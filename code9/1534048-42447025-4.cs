        private static XmlAttributeOverrides GetOverrides()
        {
            var overrides = new XmlAttributeOverrides();
            var attributes = new XmlAttributes();
            attributes.XmlElements.Add(new XmlElementAttribute(typeof(DateSafeDelivery)));
            overrides.Add(typeof(MyParent), "Delivery", attributes);
            // Ignore all DateTime properties in DateSafeDelivery
            var completed = new HashSet<Type>();
            overrides.IgnorePropertiesOfType(typeof(DateSafeDelivery), typeof(DateTime), completed);
            // Add the other 14 types as required
            return overrides;
        }
