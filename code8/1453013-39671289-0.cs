    public override void ExecuteResult(ControllerContext context)
    {
      if (context == null)
        throw new ArgumentNullException("context");
      if (this.JsonRequestBehavior == JsonRequestBehavior.DenyGet && string.Equals(context.HttpContext.Request.HttpMethod, "GET", StringComparison.OrdinalIgnoreCase))
        throw new InvalidOperationException(MvcResources.JsonRequest_GetNotAllowed);
      HttpResponseBase response = context.HttpContext.Response;
      response.ContentType = string.IsNullOrEmpty(this.ContentType) ? "application/json" : this.ContentType;
      if (this.ContentEncoding != null)
        response.ContentEncoding = this.ContentEncoding;
      if (this.Data == null)
        return;
      JavaScriptSerializer scriptSerializer = new JavaScriptSerializer();
      if (this.MaxJsonLength.HasValue)
        scriptSerializer.MaxJsonLength = this.MaxJsonLength.Value;
      if (this.RecursionLimit.HasValue)
        scriptSerializer.RecursionLimit = this.RecursionLimit.Value;
      response.Write(scriptSerializer.Serialize(this.Data));
    }
