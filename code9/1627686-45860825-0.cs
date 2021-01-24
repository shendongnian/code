    public class Turnover
    {
       public Turnover()
       {
           TurnoverDetails = new List<product>();
       }
       public List<product> TurnoverDetails { get; set; } 
    }
    Turnover turnover = new Turnover();
    turnover.TurnoverDetails.Add(new product() { ProductName = "", ProductGroup 
    = "", Amout = 0, Code = 0, Quantity = 0, Referece = "", });
    string json = JsonConvert.SerializeObject(turnover);
