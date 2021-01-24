        public static List<T> ExtractXmltoClassList<T>(HttpResponseMessage http, string elementName) where T : new()
        {
            var ctorType = typeof(T);
            var classList = new List<T>();
            var doc = JsonConvert.DeserializeXmlNode(http.Content.ReadAsStringAsync().Result, "root");
            var xdoc = XDocument.Parse(doc.InnerXml);
            var count = xdoc.Descendants(elementName).Count();
            for (var x = 0; x < count; x++) //Itterate the number of times the tag was found (= number of elements)
            {
                var newClass = new T();
                foreach (var prop in ctorType.GetProperties())
                {
                    var tags = xdoc.Descendants(elementName).Select(node => node.Element(prop.Name)).ToList();
                    if (tags.Count <= 0 || tags[x].Value.Trim() == "")
                        continue;
                    if (prop.PropertyType == typeof(int))
                        prop.SetValue(newClass, Utility.ToInt(tags[x].Value));
                    else if (prop.PropertyType == typeof(long))
                        prop.SetValue(newClass, Utility.ToLong(tags[x].Value));
                    else if (prop.PropertyType == typeof(double))
                        prop.SetValue(newClass, Utility.ToDouble(tags[x].Value));
                    else if (prop.PropertyType == typeof(float))
                        prop.SetValue(newClass, Utility.ToFloat(tags[x].Value));
                    else if (prop.PropertyType == typeof(bool))
                        prop.SetValue(newClass, Utility.ToBool(tags[x].Value));
                    else if (prop.PropertyType == typeof(string))
                        prop.SetValue(newClass, tags[x].Value);
                    else if (prop.PropertyType == typeof(DateTime))
                        prop.SetValue(newClass, Utility.ToDateTime(tags[x].Value));
                    else if (prop.PropertyType == typeof(Guid))
                        prop.SetValue(newClass, Utility.ToGuid(tags[x].Value));
                }
                classList.Add(newClass);
            }
            return classList;
        }
