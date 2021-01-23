            .AddJwtBearer(x =>
            {
              // ....
                x.Events = new JwtBearerEvents
                {
                    OnMessageReceived = context =>
                    {
                        if (context.Request.Headers.ContainsKey("sec-websocket-protocol") && context.HttpContext.WebSockets.IsWebSocketRequest)
                        {
                            var token = context.Request.Headers["sec-websocket-protocol"].ToString();
                            // token arrives as string = "client, xxxxxxxxxxxxxxxxxxxxx"
                            context.Token = token.Substring(token.IndexOf(',') + 1).Trim();
                            context.Request.Headers["sec-websocket-protocol"] = "client";
                        }
                        return Task.CompletedTask;
                    }
                };
