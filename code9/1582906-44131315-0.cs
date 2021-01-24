    public sealed class PrivateAttribute : Attribute, IAuthorizationFilter {
		public Task<HttpResponseMessage> ExecuteAuthorizationFilterAsync(
			HttpActionContext actionContext,
			CancellationToken cancellationToken,
			Func<Task<HttpResponseMessage>> continuation) {
			var claimsPrincipal = actionContext.RequestContext.Principal as ClaimsPrincipal;
			if (actionContext.RequestContext.RouteData.Values.ContainsKey(CONSTANTS.USER_ID_KEY) && claimsPrincipal != null) {
				var requestedID = actionContext.RequestContext.RouteData.Values[CONSTANTS.USER_ID_KEY];
				if (claimsPrincipal.HasClaim(CONSTANTS.USER_ID_KEY, requestedID.ToString())) {
					return continuation();
				} else { // someone is trying to get resources of another user
					return whatever fail;
				}
			} else { // there is no {id} paramter in the route, nothing to do
				return continuation();
			}
		}
		public bool AllowMultiple => false;
	}
