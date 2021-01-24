    <#=Accessibility.ForType(container)#> partial class <#=code.Escape(container)#> : DbContext
    {
        public static string ConnectionString { get; set; }
        public <#=code.Escape(container)#>()
            : base(ConnectionString)
        {
    <#
    if (!loader.IsLazyLoadingEnabled(container))
    {
    #>
            this.Configuration.LazyLoadingEnabled = false;
    <#
    }
