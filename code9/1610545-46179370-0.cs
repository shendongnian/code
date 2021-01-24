using Microsoft.Extensions.Localization;
namespace GlobalizationLibrary
{
    public class SharedResource:ISharedResource
    {
        private readonly IStringLocalizer<SharedResources> _localizer;
        public SharedResource(IStringLocalizer<SharedResources> localizer)
        {
            _localizer = localizer;
        }
        public string GetResourceValueByKey(string resourceKey)
        {
            return _localizer[resourceKey];
        }
    }}
  
