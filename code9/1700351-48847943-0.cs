    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using MongoDB.Bson.Serialization.Attributes;
    namespace NotebookAppApi.Models
    {
        public class Note
        {
            [BsonId]
            public string Id { get; set; }
            public string Body { get; set; } = string.Empty;
            public DateTime UpdatedOn { get; set; } = DateTime.Now;
            public DateTime CreatedOn { get; set; } = DateTime.Now;
            public int UserId { get; set; } = 0;
        }
    }
