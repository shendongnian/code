    using Newtonsoft.Json;
    namespace Accounts
    {
        class File
        {
            [JsonProperty("file")]
            public string Filename { get; set; }
        }
    }
