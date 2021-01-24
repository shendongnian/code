    public class StringPair
    {
        public StringPair(string a, string b)
        {
            this.Id = a;
            this.OtherField = b;
        }
        
        public StringPair()
        {
            // don't forgot parameterless ctor
        }
        
        // Define "Id" or use [BsonId] in your property or use FluentApi mapper
    
        public string Id { get; set; }
        public string OtherField { get; set; }
    }
    
    
    db = new LiteDatabase(@"albumdata.db");
    
    db_string = db.GetCollection<StringPair>("strings");
    
    // PK already contains unique index
    // db.Engine.EnsureIndex("strings", "a", true);
    db_string.Upsert(new StringPair("a", "1")); // insert
    
    db_string.Upsert(new StringPair("a", "2")); // update
