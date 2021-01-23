        public void UpdateValues(object test2, Dictionary<string, object> dict)
        {
            var fieldValues = test2.GetType()
                       .GetFields()
                       .ToList();
            foreach (var value in dict)
            {
                foreach (var field in fieldValues)
                {
                    if (value.Key == field.Name)
                    {
                        bool obj = field.FieldType == typeof(test);
                        if (obj)
                        {
                            if (dict.ContainsKey("data")) 
                            {
                            var prop = test2.GetType().GetField("data", System.Reflection.BindingFlags.Public
                            | System.Reflection.BindingFlags.Instance);
                            prop.SetValue(test2, dict["data"]);
                            break;
                            }
                        }
                        else
                        {
                            var prop = test2.GetType().GetField(value.Key, System.Reflection.BindingFlags.Public
                            | System.Reflection.BindingFlags.Instance);
                            prop.SetValue(test2, value.Value);
                            break;
                        }
                    }
                }
            }
        }
