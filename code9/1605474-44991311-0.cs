    /// <summary>
    /// Handler to assign the MD5 hash value if content is present
    /// </summary>
    public class RequestContentMd5Handler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            if (request.Content != null)
            {
                await request.Content.AssignMd5Hash().ConfigureAwait(false);
            }
    
            return await base.SendAsync(request, cancellationToken);
        }
    }
