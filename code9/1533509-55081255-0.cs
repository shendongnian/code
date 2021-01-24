    public class StatusCodeAndDtoWrapper : ObjectResult
    {
        
      
        
        public StatusCodeAndDtoWrapper(AppResponse dto, int statusCode = 200) : base(dto)
        {
            StatusCode = statusCode;
        }
        private StatusCodeAndDtoWrapper(AppResponse dto, int statusCode, string message) : base(dto)
        {
            StatusCode = statusCode;
            if (dto.FullMessages == null)
                dto.FullMessages = new List<string>(1);
            dto.FullMessages.Add(message);
        }
        private StatusCodeAndDtoWrapper(AppResponse dto, int statusCode, ICollection<string> messages) : base(dto)
        {
            StatusCode = statusCode;
            dto.FullMessages = messages;
        }
    }
