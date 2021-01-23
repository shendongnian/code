public class RocketRequest
{
    public string Id { get; set; }
    public int RocketRequestID { get; set; }
    public int LoanRocketID { get; set; }    
    public DateTime RequestDate { get; set; }    
    public int CreatedByID { get; set; }    
    public string RequestXML { get; set; }
}
var collection = db.GetCollection<RocketRequest>("RocketRequest"); 
  [1]: http://api.mongodb.com/csharp/current/html/T_MongoDB_Driver_IFindFluent_2.htm?_ga=1.164501695.1416656791.1479828462
