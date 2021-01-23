    static class Flow // not generic (same name isn't mandatory)
    {
        public static Flow<TQuery, TReply> Create (TQuery query, TReply, reply) where /* constraint */
        {
            return new Flow<TQuery, TReply> (query, reply);
        }
    }
    // usage
    Flow<Query, Reply> flow = Flow.Create (query, reply);
    // or with var
    var flow = Flow.Create (query, reply);
