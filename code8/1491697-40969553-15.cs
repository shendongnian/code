    using System.ComponentModel.DataAnnotations;
    using Microsoft.Azure.Search;
    using Microsoft.Azure.Search.Models;
    
    namespace TomAzureSearchTest
    {
        [SerializePropertyNamesAsCamelCase]
        public class TomTestModel
        {
            [Key]
            [IsFilterable]
            public string fileId { get; set; }
            [IsSearchable]
            public string fileText { get; set; }
            public string blobURL { get; set; }
            [IsSearchable]
            public string keyPhrases { get; set; }
        }
    }
