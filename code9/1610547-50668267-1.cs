    using Microsoft.Extensions.Localization;
    
    namespace ResourceLibrary
    {
        public interface ISharedResource
        {
        }
        public class SharedResource : ISharedResource
        {
            private readonly IStringLocalizer _localizer;
    
            public SharedResource(IStringLocalizer<SharedResource> localizer)
            {
                _localizer = localizer;
            }
    
            public string this[string index]
            {
                get
                {
                    return _localizer[index];
                }
            }
        }
    }
