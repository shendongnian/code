        app.Use(async (context, next) =>
            {
                var initialBody = context.Request.Body;
                using (var bodyReader = new StreamReader(context.Request.Body))
                {
                    string body = await bodyReader.ReadToEndAsync();
                    Console.WriteLine(body);
                    context.Request.Body = new MemoryStream(Encoding.UTF8.GetBytes(body));
                    await next.Invoke();
                    context.Request.Body = initialBody;
                }
            });
