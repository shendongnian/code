      public class ServiceConfig
      {
        private string web_internal
        {
          // Note it does not work without this noop getter
          get => "it's hack for Microsoft.Configuration.Binder";
          set => WebInternal = value;
        }
        
        public string WebInternal { get; set; }
      }
