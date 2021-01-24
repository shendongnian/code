    public class ApiResponse<TData>
    {        
        /// <summary>
        /// Constructor for success.
        /// </summary>
        /// <param name="data"></param>
        public ApiResponse(TData data)
        {
            Data = data;
            Success = true;
            Errors = new List<string>();
        }
        /// <summary>
        /// Constructor for failure.
        /// </summary>
        /// <param name="ex"></param>
        public ApiResponse(IEnumerable<string> errors)
        {
            Errors = errors;
            Success = false;
        }
        /// <summary>
        /// Gets whether the API call was successful.
        /// </summary>
        public bool Success { get; private set; }
        /// <summary>
        /// Gets any errors encountered if the call was not successful.
        /// </summary>
        public IEnumerable<string> Errors { get; private set; }        
        /// <summary>
        /// Gets the data resulting from the API call.
        /// </summary>
        public TData Data { get; private set; }
    }
