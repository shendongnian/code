        /// <summary>
        /// A filter that specifies the supported response content types. The request accept header is used to determine if it is a valid action
        /// </summary>
        [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
        public class AcceptHeaderAttribute : Attribute, IActionConstraint
        {
    
            public AcceptHeaderAttribute(string contentType, params string[] otherContentTypes)
            {            
                if (contentType == null)
                    throw new ArgumentNullException(nameof(contentType));
    
                // We want to ensure that the given provided content types are valid values, so
                // we validate them using the semantics of MediaTypeHeaderValue.
                MediaTypeHeaderValue.Parse(contentType);
    
                for (var i = 0; i < otherContentTypes.Length; i++)
                {
                    MediaTypeHeaderValue.Parse(otherContentTypes[i]);
                }
    
                ContentTypes = GetContentTypes(contentType, otherContentTypes);
            }
                  
            public MediaTypeCollection ContentTypes
            {
                get; set;
            }
    
            public int Order
            {
                get
                {
                    return 0;
                }
            }
    
            private bool IsSubsetOfAnyContentType(string requestMediaType)
            {
                var parsedRequestMediaType = new MediaType(requestMediaType);
                for (var i = 0; i < ContentTypes.Count; i++)
                {
                    var contentTypeMediaType = new MediaType(ContentTypes[i]);
                    if (parsedRequestMediaType.IsSubsetOf(contentTypeMediaType))
                    {
                        return true;
                    }
                }
                return false;
            }
    
            public bool Accept(ActionConstraintContext context)
            {
                var requestAccept = context.RouteContext.HttpContext.Request.Headers[HeaderNames.Accept];
                if (StringValues.IsNullOrEmpty(requestAccept))
                    return true;
    
                if (IsSubsetOfAnyContentType(requestAccept))
                    return true;
    
                return false;
            }
    
            private MediaTypeCollection GetContentTypes(string firstArg, string[] args)
            {
                var completeArgs = new List<string>();
                completeArgs.Add(firstArg);
                completeArgs.AddRange(args);
    
                var contentTypes = new MediaTypeCollection();
                foreach (var arg in completeArgs)
                {
                    contentTypes.Add(arg);
                }
    
                return contentTypes;
            }
        }
