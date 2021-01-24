    using System.Linq;
    using Microsoft.Extensions.Configuration;
    using System;
    using System.Collections.Generic;
    
    public class AppConfigurationManager
    {
        private IConfiguration _configuration;
    
        public AppConfigurationManager(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }
    
        public IDictionary<string, string> AllowedFileUploadTypes =>
                        _configuration.GetSection(nameof(AllowedFileUploadTypes)).GetChildren()
                            .Select(item => new KeyValuePair<string, string>(item.Key, item.Value))
                            .ToDictionary(x => x.Key, x => x.Value);
    
    }
