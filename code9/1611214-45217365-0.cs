            request.Headers.Add("Accept", contentType);
            foreach (var v in request.Headers.Accept)
            {
                if (v.MediaType.Contains("application/json"))
                {
                    var field = v.GetType().GetTypeInfo().BaseType.GetField("_mediaType", BindingFlags.NonPublic | BindingFlags.Instance);
                    field.SetValue(v, "application/json;masked=false");
                    v.Parameters.Clear();
                }
            }
