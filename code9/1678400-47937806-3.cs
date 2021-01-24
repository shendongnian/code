                public override FilterDecision Decide(LoggingEvent loggingEvent)
                {
                    if (loggingEvent == null)
                        throw new ArgumentNullException("loggingEvent");
        
                    if (filters.All(x => x.Decide(loggingEvent) != FilterDecision.Accept))
                    {
                        return FilterDecision.Neutral;
                    }
        
                    // All conditions are true
                    if (acceptOnMatch)
                        return FilterDecision.Accept;
                    else
                        return FilterDecision.Deny;
                }
