    public class Claim
    {
    public string ClaimNo { get; set; } 
    public string ClientName { get; set; } 
    public string Uwyear { get; set; } 
    public string AgreementNo { get; set; } 
    public string BusinessType { get; set; } 
    public DateTime? PeriodStart { get; set; } public DateTime? PeriodEnd { get; set; } 
    public string PolicyNo { get; set; } 
    public string PolicyName { get; set; } 
    public DateTime? DateOfLoss { get; set; } public string ClaimantName { get; set; } 
    public string ClaimedInsured { get; set; } 
    public DateTime? ReportDate { get; set; }
    
    }
....
    List<Claim> claims = new List<Claim>();
    
    for (int row = 1; row < maxRows; row++)
    {
          var c = new Claim();
          c.ClaimNo= valueArray[row,MapCol("ClaimNo")].ToString();
          c.ClientName= valueArray[row,MapCol("ClientName")].ToString();
           ...         
    }
    claims.Add(c);
        
