                if (eventData.Properties.ContainsKey("to"))
                {
                    object value;
                    eventData.Properties.TryGetValue("to", out value);
                    Console.WriteLine("property key: 'to' value: '{0}'", value.ToString());
                }
                if (eventData.Properties.ContainsKey("user-id"))
                {
                    object value;
                    eventData.Properties.TryGetValue("user-id", out value);
                    Console.WriteLine("property key: 'user-id' value: '{0}'", value.ToString());
                }
