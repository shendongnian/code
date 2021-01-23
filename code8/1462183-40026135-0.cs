    private static void InitializeContainer(Container container, IDataProtectionProvider DataProtectionProvider)
    {
        /* OMITTED */
        container.RegisterPerWebRequest(() => new ApplicationUserManager(container.GetInstance<IUserStore<ApplicationUser>>(), DataProtectionProvider));
    }
