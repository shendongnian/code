    <#=Accessibility.ForType(container)#> partial class <#=code.Escape(container)#> : DbContext
    {
        // Original code
        //public <#=code.Escape(container)#>()
        //    : base("name=<#=container.Name#>")
        //{
        // Modified code
        public static string ConnectionString { get; set; }
        public <#=code.Escape(container)#>()
            : base(ConnectionString)
        {
        // End of modified code
    <#
    if (!loader.IsLazyLoadingEnabled(container))
    {
    #>
            this.Configuration.LazyLoadingEnabled = false;
    <#
    }
