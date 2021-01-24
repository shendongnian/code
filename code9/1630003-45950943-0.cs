    public HttpResponseMessage Get(string category)
    {
        // Step 1: First check the obvious issues
        if (string.IsNullOrWhiteSpace(category))
        {
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }
        try
        {
            // The client has sent us a category. Now we have to do our best to 
            // satisfy the request.
            // Step 2: Optional Step: First check to see if we have the category
            string cat = _categoryRepository.Get(category);
            if (string.IsNullOrWhiteSpace(cat))
            {
                var message = new HttpResponseMessage(HttpStatusCode.NotFound);
                message.Content = new StringContent($"The category with the name {category} was not found.");
                throw new HttpResponseException(message);
            }
            // Step 3: Category exists so let's return the products
            IEnumerable<ArticlesDto> articlesByCategory = _articlesrepository.Find(category);
            // Even if the list is empty, we can still return it to tell
            // the client 0 items were found
            // for the category. 
            return Request.CreateResponse(HttpStatusCode.OK, articlesByCategory);
        }
        catch (Exception ex)
        {
            // Something went wrong on our side (NOT the client's fault). So we need to:
            // 1. Log the error so we can troubleshoot it later
            // 2. Let the client know it is not their fault but our fault.
            return Request.CreateResponse(HttpStatusCode.InternalServerError);
        }
    }
