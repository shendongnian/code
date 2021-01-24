    /// <summary>
        ///  an ApiBadRequestResponse class to handle validation errors from modelState or exception.
        /// </summary>
        public class ApiBadRequestResponse : ApiResponse
        {
            public IEnumerable<string> Errors { get; }
    
            public ApiBadRequestResponse(ModelStateDictionary modelState)
                : base(HttpStatusCode.BadRequest) //400)
            {
                if (modelState.IsValid)
                {
                    throw new ArgumentException("ModelState must be invalid", nameof(modelState));
                }
    
                Errors = modelState.SelectMany(x => x.Value.Errors)
                    .Select(x => x.ErrorMessage).ToArray();
            }
    
            public ApiBadRequestResponse(Exception exception, string message=null)
                : base(HttpStatusCode.BadRequest, message) //400)
            {
                Errors = new List<string>() {exception.ToString()};
            }
        }
