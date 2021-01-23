    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using System.Web.Http.Controllers;
    namespace Application {
        public class HasActionAttribute : AuthorizeAttribute {
            public string Actions { get; set; }
            public override void OnAuthorization(HttpActionContext actionContext) {
                UserCache userCache = HELPERS.GetCurrentUserCache();
                List<string> actionsList = Actions.Split(',').Select(a=>a.Trim(' ')).ToList();
                if (!userCache.UserActionsDictionary[userCache.CurrentTenantID.ToString()].Intersect(actionsList).Any()) {
                    HandleUnauthorizedRequest(actionContext);
                }
            }
            protected override void HandleUnauthorizedRequest(HttpActionContext filterContext) {
                filterContext.Response = new HttpResponseMessage(HttpStatusCode.Forbidden) { Content = new StringContent("Action not allowed for the current user") };
            }
        }
    }
