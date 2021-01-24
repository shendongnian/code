    [Route("/people")]
    [Route("/people/sex/{Sex}")]
    [Route("/people/sex/{Sex}/age-over/{AgeOver}")]
    public class SearchPeopleRoute
    {
         public string Sex { get; set; }
         public int? AgeOver { get; set; }
    }
