        public string ToQueryString(int pageIncrement)
        {
            List<string> propValues = new List<string>();
            foreach(var prop in GetType().GetProperties())
            {
                var name = prop.Name;
                var value = prop.GetValue(this);
                if (name == "PageNo")
                {
                    value == (int)value + pageIncrement;
                }
                if (value != null)
                {
                    propValues .Add(String.Format("{0}={1}", name, value));
                }
            }
            return "?" + String.Join("&", propValues);
        }
