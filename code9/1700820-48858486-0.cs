    public class Flight
    {
            [Key]
            public int flight_id { get; set; }
            [ForeignKey("route_id")]
            public int route_id { get; set; }
            public int airline_id { get; set; }
            public DateTime departure_time { get; set; }
            public DateTime arrival_time { get; set; }
            public List<Route> Routes {get; set} //including the Route Model for 
                                                 //you to properly reference it.
    }
