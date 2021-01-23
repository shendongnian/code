    using Microsoft.Azure.Search.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace AzureSearchTextAnalytics
    {
    [SerializePropertyNamesAsCamelCase]
    public class OCRTextIndex
    {
        public string fileId { get; set; }
        public string[] keyPhrases { get; set; }
    }
    }
