    services.AddMvc(options =>
                {
                    options.UseCustomStringModelBinder();
                    options.AllowEmptyInputInBodyModelBinding = true;
                    foreach (var formatter in options.InputFormatters)
                    {
                        if (formatter.GetType() == typeof(SystemTextJsonInputFormatter))
                            ((SystemTextJsonInputFormatter)formatter).SupportedMediaTypes.Add(
                                Microsoft.Net.Http.Headers.MediaTypeHeaderValue.Parse("text/plain"));
                    }
                }).AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                });
