            public static class LinkExtensions
            {
                public static dynamic AddLinks<T>(this T content, params object[] links)
                {
                    IDictionary<string, object> result = new ExpandoObject();
    
                    typeof (T)
                        .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                        .ToList()
                        .ForEach(_ => result[_.Name] = _.GetValue(content));
    
                    result["links"] = links;
    
                    return result;
                }
            }
    - Use it:
 
            public IHttpActionResult Post(Appointment appointment)
            {
                return Ok(appointment.AddLinks(new HyperMedia
                { 
                    Href = Url.Link("AppointmentDeletion", new { slot = 1234 }), 
                    Rel = "delete" 
                }));
            }
