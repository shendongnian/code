    public override void OnActionExecuting(ActionExecutingContext filterContext)
    {
            var httpContext = HttpContext.Current;
            if (httpContext != null && httpContext.Request.Form.HasKeys())
            {
                var form = filterContext.HttpContext.Request.Form;
                var products = form.AllKeys.SelectMany(form.GetValues, (k, v) => new { key = k, value = v });
                System.Diagnostics.Debug.WriteLine("The form is = " + form);
                if (form != null)
                {
                    foreach (var pModel in products)
                    {
                        System.Diagnostics.Debug.WriteLine("The pModel.Key is = " + pModel.key);
                        System.Diagnostics.Debug.WriteLine("The pModel.Value is = " + pModel.value);
                    }
                }
            }
    }
