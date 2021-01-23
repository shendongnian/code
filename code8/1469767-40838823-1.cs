     public override Task WriteToStreamAsync(Type type, object value, Stream writeStream, HttpContent content, TransportContext transportContext)
        {
            StreamWriter writer = new StreamWriter(writeStream);
            JsonWriter jsonwriter = new JsonTextWriter(writer);
            if (type == typeof(OperationOutcome))
            {
                Resource resource = (Resource)value;
                FhirSerializer.SerializeResource(resource, jsonwriter);
            }
            else if (typeof(Resource).IsAssignableFrom(type))
            {
                if (value != null)
                {
                    Resource r = value as Resource;
                    SummaryType st = SummaryType.False;
                    if (r.UserData.ContainsKey("summary-type"))
                        st = (SummaryType)r.UserData["summary-type"];
                    FhirSerializer.SerializeResource(r, jsonwriter, st);
                }
            }
            writer.Flush();
            return Task.FromResult<object>(null); // Task.CompletedTask // When we update to .net 4.6;
        }
