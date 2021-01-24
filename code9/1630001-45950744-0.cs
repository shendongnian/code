        public IEnumerable<string> Get()
        {
            try
            {
                throw new InvalidOperationException("Invalid Operation");
            }
            catch(Exception ex)
            {
                var res = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                res.Content = new StringContent(ex.Message);
                throw new HttpResponseException(res);
            }
        }
