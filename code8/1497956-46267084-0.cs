    public class AppStateService
    { 
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ITempDataProvider _tempDataProvider;
        private IDictionary<string, object> _data;
        public AppStateService(IHttpContextAccessor httpContextAccessor, ITempDataProvider tempDataProvider, UserManager<EntsogUser> userManager, CompanyRepository companyRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _tempDataProvider = tempDataProvider;
            _data = _tempDataProvider.LoadTempData(_httpContextAccessor.HttpContext);
        }
        private void SetValue(string name, object value)
        {
            _data[name] = value;
            _tempDataProvider.SaveTempData(_httpContextAccessor.HttpContext,_data);
        }
        private object GetValue(string name)
        {
            
            if (!_data.ContainsKey(name))
                return null;
            return _data[name];
        }
    }
