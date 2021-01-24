     public class ProductViewDto
     { 
        public int  Id{get;set;}
        public DateTime EndDate {get;set;}
        public DateTime  StartDate{get;set;} 
     }
     var products = dalLayer.GetProductsList().Select(
                            pr => new ProductViewDto
                            {
                                Id =pr.Id,
                                EndDate =pr.EndDate,
                                StartDate=pr.Startdate,
                            });
