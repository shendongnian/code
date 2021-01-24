                var headers = _.Context.Request.GetTypedHeaders();
                headers.CacheControl = new CacheControlHeaderValue
                {
                    MaxAge = TimeSpan.FromHours(12)
                };
