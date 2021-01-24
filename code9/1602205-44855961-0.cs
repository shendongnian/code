            string s = "{\"subform_12\":{\"multiline_2\":\"Subform 1 Long Text\",\"listpicker_5\":\"High\",\"alpha_1\":\"SubForm 1 Text\"},\"subform_13\":{\"multiline_2\":\"Subform 2 Long Text\",\"alpha_1\":\"SubForm 2 Text\"}}";
            JavaScriptSerializer ser = new JavaScriptSerializer();
            Dictionary<string, object> obj = ser.DeserializeObject(s) as Dictionary<string, object>;
            
            // combined dictionary of all results
            Dictionary<string, object> result = new Dictionary<string, object>();
            // an intermediary dictionary to house the results of each object
            Dictionary<string, object> separated = new Dictionary<string, object>();
            // a list to hold the json representation of each separate object
            List<String> allJson = new List<string>();
            foreach (KeyValuePair<string, object> src in obj)
            {
                Dictionary<string, object> children = (Dictionary<string, object>)src.Value;
                Dictionary<string, object> t = new Dictionary<string, object>();
                separated = new Dictionary<string, object>();
                List<object> l = new List<object>();
                foreach (KeyValuePair<string, object> child in children)
                {
                    t.Add("fieldKey", child.Key);
                    t.Add("value", child.Value);
                    l.Add(t);
                    t = new Dictionary<string, object>();
                }
                separated.Add(src.Key, l.ToArray());
                allJson.Add(ser.Serialize(separated));
                result.Add(src.Key, l.ToArray());
            }
            // final string containing all transformed objects combined.            
            string combined = ser.Serialize(result);
