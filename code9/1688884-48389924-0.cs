    using System;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Security.Claims;
    using System.Security.Principal;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Web.Http;
    using System.Web.Http.Filters;
    namespace myExample
    {
        public class ExternalAuthenticationAttribute : IAuthenticationFilter
        {
            public virtual bool AllowMultiple
            {
                get { return false; }
            }
            public Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
            {
                // get request + authorization headers
                HttpRequestMessage request = context.Request;
                AuthenticationHeaderValue authorization = request.Headers.Authorization;
                // check for username and password (regardless if it was validated on the client, server should check)
                // this will only accept Basic Authorization
                if (String.IsNullOrEmpty(authorization.Parameter) || authorization.Scheme != "Basic")
                {
                    // Authentication was attempted but failed. Set ErrorResult to indicate an error.
                    context.ErrorResult = new AuthenticationFailureResult("Missing credentials", request);
                    return null;
                }
                var userNameAndPasword = GetCredentials(authorization.Parameter);
                if (userNameAndPasword == null)
                {
                    // Authentication was attempted but failed. Set ErrorResult to indicate an error.
                    context.ErrorResult = new AuthenticationFailureResult("Could not get credentials", request);
                    return null;
                }
                // now that we have the username + password call User manager API
                var client = new HttpClient();
                // POST USERNAME + PASSWORD INSIDE BODY, not header, not query string. ALSO USE HTTPS to make sure it is sent encrypted
                var response = AuthenticateAgainstUserMapagerApi1(userNameAndPasword, client);
                // THIS WILL WORK IN .NET CORE 1.1. ALSO USE HTTPS to make sure it is sent encrypted
                //var response = AuthenticateAgainstUserMapagerApi2(client, userNameAndPasword);
                // parse response
                if (!response.IsSuccessStatusCode)
                {
                    context.ErrorResult = new AuthenticationFailureResult("Invalid username or password", request);
                }
                else
                {
                    var readTask = response.Content.ReadAsStringAsync();
                    var content = readTask.Result;
                    context.Principal = GetPrincipal(content); // if User manager API returns a user principal as JSON we would 
                }
                return null;
            }
            //private static HttpResponseMessage AuthenticateAgainstUserMapagerApi2(HttpClient client, Tuple<string, string> userNameAndPasword)
            //{
            //    client.SetBasicAuthentication(userNameAndPasword.Item1, userNameAndPasword.Item2);
            //    var responseTask = client.GetAsync("https://your_user_manager_api_URL/api/authenticate");
            //    return responseTask.Result;
            //}
            private static HttpResponseMessage AuthenticateAgainstUserMapagerApi1(Tuple<string, string> userNameAndPasword, HttpClient client)
            {
                var credentials = new
                {
                    Username = userNameAndPasword.Item1,
                    Password = userNameAndPasword.Item2
                };
                var responseTask = client.PostAsJsonAsync("https://your_user_manager_api_URL/api/authenticate", credentials);
                var response = responseTask.Result;
                return response;
            }
            public IPrincipal GetPrincipal(string principalStr)
            {
                // deserialize principalStr and return a proper Principal instead of ClaimsPrincipal below
                return new ClaimsPrincipal();
            }
            private static Tuple<string, string> GetCredentials(string authorizationParameter)
            {
                byte[] credentialBytes;
                try
                {
                    credentialBytes = Convert.FromBase64String(authorizationParameter);
                }
                catch (FormatException)
                {
                    return null;
                }
                try
                {
                    // make sure you use the proper encoding which match client
                    var encoding = Encoding.ASCII;
                    string decodedCredentials;
                    decodedCredentials = encoding.GetString(credentialBytes);
                    int colonIndex = decodedCredentials.IndexOf(':');
                    string userName = decodedCredentials.Substring(0, colonIndex);
                    string password = decodedCredentials.Substring(colonIndex + 1);
                    return new Tuple<string, string>(userName, password);
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
            public Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
        public class AuthenticationFailureResult : IHttpActionResult
        {
            public AuthenticationFailureResult(string reasonPhrase, HttpRequestMessage request)
            {
                ReasonPhrase = reasonPhrase;
                Request = request;
            }
            public string ReasonPhrase { get; private set; }
            public HttpRequestMessage Request { get; private set; }
            public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
            {
                return Task.FromResult(Execute());
            }
            private HttpResponseMessage Execute()
            {
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
                response.RequestMessage = Request;
                response.ReasonPhrase = ReasonPhrase;
                return response;
            }
        }
    }
