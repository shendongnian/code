    // To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
    //
    //    using QuickType;
    //
    //    var data = GettingStarted.FromJson(jsonString);
    //
    namespace QuickType
    {
        using System;
        using System.Net;
        using System.Collections.Generic;
    
        using Newtonsoft.Json;
    
        public partial class GettingStarted
        {
            [JsonProperty("routes")]
            public Route[] Routes { get; set; }
    
            [JsonProperty("geocoded_waypoints")]
            public GeocodedWaypoint[] GeocodedWaypoints { get; set; }
    
            [JsonProperty("status")]
            public string Status { get; set; }
        }
    
        public partial class Route
        {
            [JsonProperty("overview_polyline")]
            public Polyline OverviewPolyline { get; set; }
    
            [JsonProperty("copyrights")]
            public string Copyrights { get; set; }
    
            [JsonProperty("bounds")]
            public Bounds Bounds { get; set; }
    
            [JsonProperty("legs")]
            public Leg[] Legs { get; set; }
    
            [JsonProperty("warnings")]
            public object[] Warnings { get; set; }
    
            [JsonProperty("summary")]
            public string Summary { get; set; }
    
            [JsonProperty("waypoint_order")]
            public object[] WaypointOrder { get; set; }
        }
    
        public partial class Polyline
        {
            [JsonProperty("points")]
            public string Points { get; set; }
        }
    
        public partial class Bounds
        {
            [JsonProperty("northeast")]
            public EndLocation Northeast { get; set; }
    
            [JsonProperty("southwest")]
            public EndLocation Southwest { get; set; }
        }
    
        public partial class EndLocation
        {
            [JsonProperty("lat")]
            public double Lat { get; set; }
    
            [JsonProperty("lng")]
            public double Lng { get; set; }
        }
    
        public partial class Leg
        {
            [JsonProperty("end_location")]
            public EndLocation EndLocation { get; set; }
    
            [JsonProperty("duration")]
            public Distance Duration { get; set; }
    
            [JsonProperty("distance")]
            public Distance Distance { get; set; }
    
            [JsonProperty("end_address")]
            public string EndAddress { get; set; }
    
            [JsonProperty("start_location")]
            public EndLocation StartLocation { get; set; }
    
            [JsonProperty("traffic_speed_entry")]
            public object[] TrafficSpeedEntry { get; set; }
    
            [JsonProperty("start_address")]
            public string StartAddress { get; set; }
    
            [JsonProperty("steps")]
            public Step[] Steps { get; set; }
    
            [JsonProperty("via_waypoint")]
            public object[] ViaWaypoint { get; set; }
        }
    
        public partial class Distance
        {
            [JsonProperty("text")]
            public string Text { get; set; }
    
            [JsonProperty("value")]
            public long Value { get; set; }
        }
    
        public partial class Step
        {
            [JsonProperty("html_instructions")]
            public string HtmlInstructions { get; set; }
    
            [JsonProperty("duration")]
            public Distance Duration { get; set; }
    
            [JsonProperty("distance")]
            public Distance Distance { get; set; }
    
            [JsonProperty("end_location")]
            public EndLocation EndLocation { get; set; }
    
            [JsonProperty("polyline")]
            public Polyline Polyline { get; set; }
    
            [JsonProperty("maneuver")]
            public string Maneuver { get; set; }
    
            [JsonProperty("start_location")]
            public EndLocation StartLocation { get; set; }
    
            [JsonProperty("travel_mode")]
            public string TravelMode { get; set; }
        }
    
        public partial class GeocodedWaypoint
        {
            [JsonProperty("partial_match")]
            public bool? PartialMatch { get; set; }
    
            [JsonProperty("geocoder_status")]
            public string GeocoderStatus { get; set; }
    
            [JsonProperty("place_id")]
            public string PlaceId { get; set; }
    
            [JsonProperty("types")]
            public string[] Types { get; set; }
        }
    
        public partial class GettingStarted
        {
            public static GettingStarted FromJson(string json) => JsonConvert.DeserializeObject<GettingStarted>(json, Converter.Settings);
        }
    
        public static class Serialize
        {
            public static string ToJson(this GettingStarted self) => JsonConvert.SerializeObject(self, Converter.Settings);
        }
    
        public class Converter
        {
            public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
            {
                MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
                DateParseHandling = DateParseHandling.None,
            };
        }
    }
