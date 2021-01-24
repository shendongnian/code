    public class appNfam
    { ...
        [ForeignKey("appID")] // Or set it in configuration
        public virtual famProd app {get; set;}
    }
