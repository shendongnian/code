        public static void SetPropertyValues(object obj)
        {
            IEnumerable<PropertyInfo> props = obj.GetType().GetProperties().Where(x => x.Name.EndsWith("Specified"));
            List<Tuple<string, string>> propertyList = new List<Tuple<string, string>>();
            foreach (var item in props)            
                propertyList.Add(new Tuple<string, string>(item.Name.Replace("Specified",""), item.Name));            
            
            foreach (var item in propertyList)           
                setPropertyValue(obj, item.Item1, item.Item2);            
        }
        private static void setPropertyValue(object obj, string propertyName, string flagName)
        {
            IEnumerable<PropertyInfo> props = obj.GetType().GetProperties()
                .Where(x => x.Name == propertyName || x.Name == flagName);
            var propValue = props.FirstOrDefault(x => x.Name == propertyName).GetValue(obj);
            if (props?.Count() == 2 && propValue != null && checkMinValue(propValue.GetType(), propValue))
                props.FirstOrDefault(x => x.Name == flagName).SetValue(obj, true);
        }
        private static bool checkMinValue(Type type, object obj )
        {
            if (type.Name == "DateTime")
                return Convert.ToDateTime(obj) != DateTime.MinValue;
            if (type.Name == "Double")
                return Convert.ToDouble(obj) != double.MinValue;
            if (type.Name == "Int32")
                return Convert.ToInt32(obj) != Int32.MinValue;
            return true;
        }
