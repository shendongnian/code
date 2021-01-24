    using Microsoft.AspNetCore.Mvc;
    public class Package
    {
         [BindProperty(Name ="carrier")]
         public string Carrier { get; set; }
         [BindProperty(Name ="trackingNumber")]
         public string TrackingNumber { get; set; }
    }
