    using (WebApp.Start(url, (app) =>
    {
        HttpListener listener = (HttpListener)appBuilder.Properties["System.Net.HttpListener"];
        listener.AuthenticationSchemes = AuthenticationSchemes.IntegratedWindowsAuthentication;
        ...
    }
