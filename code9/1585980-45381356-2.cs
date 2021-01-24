    using Microsoft.AspNetCore.Antiforgery;
    using Microsoft.AspNetCore.Http;
    
    namespace AntiForgeryStrategiesCore
    {
        public class SingleTokenAntiforgeryAdditionalDataProvider : IAntiforgeryAdditionalDataProvider
        {
            private const string TokenKey = "SingleTokenKey";
    
            public string GetAdditionalData(HttpContext context)
            {
                var token = TokenGenerator.GetRandomToken();
                context.Session.SetString(TokenKey, token);
                return token;
            }
    
            public bool ValidateAdditionalData(HttpContext context, string additionalData)
            {
                var token = context.Session.GetString(TokenKey);
                context.Session.Remove(TokenKey);
                return token == additionalData;
            }
        }
    }
