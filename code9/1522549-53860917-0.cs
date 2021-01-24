        public async Task<IActionResult> Get(Guid id)
        {
            var responseMessage = HttpContext.GetHttpRequestMessage().CreateResponse(HttpStatusCode.OK,
                new YourObject()
                {
                    Id = Id,
                    Name = Name
                });
            return new ResponseMessageResult(responseMessage);
        }
