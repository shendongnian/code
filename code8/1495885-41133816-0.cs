        public virtual async Task<HttpResponseMessage> Post(object value)
        {
            var model = Parse(value);
            await store.CreateAsync(model);
            return Request.CreateResponse(HttpStatusCode.Created);
        }
