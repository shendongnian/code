    using Nest;
    using System;
    [ElasticsearchType(Name = "Name_Of_The_Mapping_In_Index_Mappings")]
    public class MySearchType {
    
            [Text(Name = "_id")]
            public string Id { get; set; }
    
            [Date(Name = "@timestamp")]
            public DateTime Timestamp { get; set; }
    
            [Number(NumberType.Long, Name = "some_numeric_property_in_the_mapping")] 
            public long SomeNumericProperty { get; set; }
    }
