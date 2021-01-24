		private static bool sourceDomainIsAllowed(ActionExecutingContext filterContext, List<string> allowedDomains)
		{
			var request = filterContext?.RequestContext?.HttpContext?.Request;
			var referrerHost = request?.UrlReferrer?.Host;
			var originKey = request?.Headers.AllKeys.FirstOrDefault(k => k.EqualsIgnoreCase("Origin"));
			if (!string.IsNullOrWhiteSpace(referrerHost))
			{
				return allowedDomains.Contains(referrerHost);
			}
			else if (!string.IsNullOrWhiteSpace(originKey))
			{
				var origin = request.Headers[originKey];
				var uri = new Uri(origin);
				return allowedDomains.Contains(uri.Host);
			}
			return false;
		}
