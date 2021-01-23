    protected override JsonResult Json(object data, string contentType, Encoding contentEncoding, JsonRequestBehavior behavior)
    {
        return new JsonNetResult(base.Json(data, contentType, contentEncoding, behavior));
    }
    private class JsonNetResult : JsonResult
    {
        public JsonNetResult()
        {
            this.ContentType = "application/json";
        }
    
        public JsonNetResult(JsonResult existing)
        {
            this.ContentEncoding = existing.ContentEncoding;
            this.ContentType = !string.IsNullOrWhiteSpace(existing.ContentType) ? existing.ContentType : "application/json";
            this.Data = existing.Data;
            this.JsonRequestBehavior = existing.JsonRequestBehavior;
        }
    
        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            if ((this.JsonRequestBehavior == JsonRequestBehavior.DenyGet) && string.Equals(context.HttpContext.Request.HttpMethod, "GET", StringComparison.OrdinalIgnoreCase))
            {
                base.ExecuteResult(context);                            // Delegate back to allow the default exception to be thrown
            }
    
            HttpResponseBase response = context.HttpContext.Response;
            response.ContentType = this.ContentType;
    
            if (this.ContentEncoding != null)
            {
                response.ContentEncoding = this.ContentEncoding;
            }
    
            if (this.Data != null)
            {
                // Replace with your favourite serializer.
                new Newtonsoft.Json.JsonSerializer().Serialize(response.Output, this.Data);
            }
        }
    }
        
