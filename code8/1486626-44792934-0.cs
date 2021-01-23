    using System;
    using System.Collections.Generic;
    using Xamarin.Auth;
    
    namespace Alerte.Health.App.Droid.Classes
    {
        public class MyOAuth2Authenticator : OAuth2Authenticator
        {
            public MyOAuth2Authenticator(string clientId, string scope, Uri authorizeUrl, Uri redirectUrl, GetUsernameAsyncFunc getUsernameAsync = null, bool isUsingNativeUI = false) : base(clientId, scope, authorizeUrl, redirectUrl, getUsernameAsync, isUsingNativeUI)
            {
            }
    
            public MyOAuth2Authenticator(string clientId, string clientSecret, string scope, Uri authorizeUrl, Uri redirectUrl, Uri accessTokenUrl, GetUsernameAsyncFunc getUsernameAsync = null, bool isUsingNativeUI = false) : base(clientId, clientSecret, scope, authorizeUrl, redirectUrl, accessTokenUrl, getUsernameAsync, isUsingNativeUI)
            {
            }
    
            protected override void OnCreatingInitialUrl(IDictionary<string, string> query)
            {
                query.Add("nonce",Guid.NewGuid().ToString("N"));
            }
        }
    }
