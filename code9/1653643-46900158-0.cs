    if (Sitecore.ItemWebApi.Context.Current != null)
    {
        Mode mode = Sitecore.ItemWebApi.Context.Current.Settings.Mode;
        AccessType access = Sitecore.ItemWebApi.Context.Current.Settings.Access;
        bool anon = Sitecore.ItemWebApi.Context.Current.Settings.AnonymousAcessAllowed;
    }
