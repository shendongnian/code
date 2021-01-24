    [DataContract]
    public class Pagination
    {
        [DataMember(Name = "totalitems")]
        public int Totalitems { get; set; }
        [DataMember(Name = "itemsperpage")]
        public int Itemsperpage { get; set; }
    }
    [DataContract]
    public class Six // Fixed name from 6
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }
        [DataMember(Name = "name")]
        public string Name { get; set; }
        [DataMember(Name = "city")]
        public string City { get; set; }
        [DataMember(Name = "slug_name")]
        public string SlugName { get; set; }
    }
    [DataContract]
    public class Provinces
    {
        [DataMember(Name = "6")]
        public Six Six { get; set; }
    }
    [DataContract]
    public class News
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }
        [DataMember(Name = "title")]
        public string Title { get; set; }
        [DataMember(Name = "shortcut")]
        public string Shortcut { get; set; }
        [DataMember(Name = "content")]
        public string Content { get; set; } // Fixed type from object
        [DataMember(Name = "rso_alarm")]
        public string RsoAlarm { get; set; }
        [DataMember(Name = "rso_icon")]
        public string RsoIcon { get; set; } // Fixed type from object
        [DataMember(Name = "valid_from")]
        public string ValidFrom { get; set; }
        [DataMember(Name = "0")]
        public string Zero { get; set; }  // Fixed name from 0
        [DataMember(Name = "valid_to")]
        public string ValidTo { get; set; }
        [DataMember(Name = "1")]
        public string One { get; set; } // Fixed name from 1
    #if false
        // Removed since the correct type is unknown.
        [DataMember(Name = "repetition")]
        public object Repetition { get; set; }
    #endif
        [DataMember(Name = "longitude")]
        public string Longitude { get; set; }
        [DataMember(Name = "latitude")]
        public string Latitude { get; set; }
        [DataMember(Name = "water_level_value")]
        public int WaterLevelValue { get; set; } // Fixed type to int
        [DataMember(Name = "water_level_warning_status_value")]
        public int WaterLevelWarningStatusValue { get; set; } // Fixed type to int
        [DataMember(Name = "water_level_alarm_status_value")]
        public int WaterLevelAlarmStatusValue { get; set; } // Fixed type to int
        [DataMember(Name = "water_level_trend")]
        public string WaterLevelTrend { get; set; } // This must remain a string since it appears as a non-numeric empty string in the JSON: "".
        [DataMember(Name = "river_name")]
        public string RiverName { get; set; }
        [DataMember(Name = "location_name")]
        public string LocationName { get; set; }
        [DataMember(Name = "created_at")]
        public string CreatedAt { get; set; }
        [DataMember(Name = "2")]
        public string Two { get; set; } // // Fixed name from 2
        [DataMember(Name = "updated_at")]
        public string UpdatedAt { get; set; }
        [DataMember(Name = "3")]
        public string Three { get; set; } // Fixed name from 3
        [DataMember(Name = "type")]
        public string Type { get; set; }
        [DataMember(Name = "provinces")]
        public Provinces Provinces { get; set; }
    }
    [DataContract]
    public class ApiRegionalne
    {
        [DataMember(Name = "pagination")]
        public Pagination Pagination { get; set; }
        [DataMember(Name = "newses")]
        public IList<News> Newses { get; set; }
    }
