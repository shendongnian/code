            foreach(var key in schema.Payload.Keys.ToList())
            {
                if(schema.Payload[key].GetType().IsArray)
                {
                    string[] value = schema.Payload[key] as string[];
                    schema.Payload[key] = value[0];
                    double dValue;
                    if (double.TryParse((string)schema.Payload[key], out dValue))
                        schema.Payload[key] = dValue;
                }
            }
