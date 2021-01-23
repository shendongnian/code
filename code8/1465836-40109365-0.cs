        private class ObjectWithOptionalMessage
        {
            [JsonProperty(TypeNameHandling = TypeNameHandling.None)]
            public Message? Message { get; }
            public ObjectWithOptionalMessage(Message? message)
            {
                Message = message;
            }
        }
