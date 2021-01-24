    public ActionResult Index(string type)
    {
      var entityType = Type.GetType(type);
      // reflection
      var methods = typeof(ContextDb).GetMethods("Set");
      // Not tested, but something like the following
      // Find the Generic Version
      var method = methods.Where(m => m.IsGenericMethod).FirstOrDefault();
      // Make the method info for the typed method
      var methodInfo = method.MakeGenericMethod(entityType);
      // Invoke method, cast as needed, get value
      var result = (methodInfo.Invoke(ContextDb) as DbSet).FirstOrDefault();
      return Json(result);
    }
