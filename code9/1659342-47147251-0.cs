        public async Task<HttpResponseMessage> Post()
        {
            if (HttpContext.Request.Headers["aeg-event-type"].FirstOrDefault() == "SubscriptionValidation")
            {
                using (var reader = new StreamReader(Request.Body, Encoding.UTF8))
                {
                    var result = await reader.ReadToEndAsync();
                    var validationRequest = JsonConvert.DeserializeObject<GridEvent[]>(result);
                    var validationCode = validationRequest[0].Data["validationCode"];
                    var validationResponse = JsonConvert.SerializeObject(new {validationResponse = validationCode});
                    return new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK, 
                        Content = new StringContent(validationResponse)
                    };                       
                }
            }
            // Handle normal blob event here
            return new HttpResponseMessage { StatusCode = HttpStatusCode.OK };
        }
