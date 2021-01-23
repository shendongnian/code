        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid && context.HttpContext.Request.Method == "PATCH")
            {
                var modelStateErrors = context.ModelState.Where(model =>
                {
                    // ignore only if required error is present
                    if (model.Value.Errors.Count == 1)
                    {
                        // assuming required validation error message contains word "required"
                        return model.Value.Errors.FirstOrDefault().ErrorMessage.Contains("required");
                    }
                    return false;
                });
                foreach (var errorModel in modelStateErrors)
                {
                    context.ModelState.Remove(errorModel.Key.ToString());
                }
            }
            if (!context.ModelState.IsValid)
            {
                var modelErrors = new Dictionary<string, Object>();
                modelErrors["message"] = "The request has validation errors.";
                modelErrors["errors"] = new SerializableError(context.ModelState);
                context.Result = new BadRequestObjectResult(modelErrors);
            }
        }
