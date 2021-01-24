        public override Task OnConnectedAsync()
        {
            var httpContext = Context.GetHttpContext();
            if (httpContext == null)
                throw new Exception("...");
            var query = httpContext.Request.Query;
            var userId = query.GetQueryParameterValue<long>("Foo");
            var clientId = query.GetQueryParameterValue<string>("Bar");
            var connectionId = Context.ConnectionId;
            [...]
            return base.OnConnectedAsync();
        }
