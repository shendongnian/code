    public ProcessorMatch CanProcess(MediaRange requestedMediaRange, dynamic model, NancyContext context)
        {
            return context.Request.Path != "/" && 
                !context.Request.Path.StartsWith("/someroute/") && 
                !context.Request.Path.StartsWith("/someotherroute") &&
                !context.Request.Path.StartsWith("/login")
                ? new ProcessorMatch
                {
                    ModelResult = MatchResult.DontCare,
                    RequestedContentTypeResult = MatchResult.ExactMatch
                }
                : new ProcessorMatch
                {
                    ModelResult = MatchResult.DontCare,
                    RequestedContentTypeResult = MatchResult.NoMatch
                };
        }
