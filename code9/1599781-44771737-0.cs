    [Tag("clubs")]
    [Route("/clubs", "GET")]
    public class GetClubs {}
    
    [Tag("clubs")]
    [Route("/clubs/{Id}", "PUT")]
    public class UpdateClub 
    {
        public int Id { get; set; }
    }
