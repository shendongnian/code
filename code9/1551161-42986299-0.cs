    protected internal virtual NegotiatedContentResult<T> Content<T>(HttpStatusCode statusCode, T value);        
    protected internal FormattedContentResult<T> Content<T>(HttpStatusCode statusCode, T value, MediaTypeFormatter formatter);        
    protected internal virtual FormattedContentResult<T> Content<T>(HttpStatusCode statusCode, T value, MediaTypeFormatter formatter, MediaTypeHeaderValue mediaType);    
    protected internal FormattedContentResult<T> Content<T>(HttpStatusCode statusCode, T value, MediaTypeFormatter formatter, string mediaType);    
    protected internal virtual OkResult Ok();
    protected internal virtual OkNegotiatedContentResult<T> Ok<T>(T content);
