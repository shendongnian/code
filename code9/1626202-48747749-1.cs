    #if WEBLISTENER
        .UseWebListener(options =>
        {
            options.ListenerSettings.Authentication.Schemes = AuthenticationSchemes.Negotiate | AuthenticationSchemes.NTLM;
            options.ListenerSettings.Authentication.AllowAnonymous = false;
        })
    #endif
    #if IISEXPRESS
        /* ... */
    #endif
