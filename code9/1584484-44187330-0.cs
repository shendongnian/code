        //in base controller
        private void SetRouteValues(string action, string controller, object routeValues)
        {
            RouteData.Values["action"] = action;
            RouteData.Values["controller"] = controller;
            if (routeValues != null)
            {
                var otherRouteData = new RouteValueDictionary(routeValues);
                foreach (var key in otherRouteData.Keys)
                {
                    RouteData.Values[key] = otherRouteData[key];
                }
            }
        }
        protected RedirectToRouteResult RedirectToAction<TController>(Expression<Func<TController, object>> actionExpression, object routeValues) where TController : Controller
        {
            var controllerName = typeof(TController).GetControllerName();
            var actionName = actionExpression.GetActionName();
            SetRouteValues(actionName, controllerName, routeValues);
            return new RedirectToRouteResult("Default", RouteData.Values);
        }
    //helper class
    public static class AdditionUrlHelperExtensions
	{
		public static string GetControllerName(this Type controllerType)
		{
			var controllerName = controllerType.Name.Replace("Controller", string.Empty);
			return controllerName;
		}
		public static string GetActionName<TController>(this Expression<Func<TController, object>> actionExpression)
		{
			var actionName = ((MethodCallExpression) actionExpression.Body).Method.Name;
			return actionName;
		}
	}
