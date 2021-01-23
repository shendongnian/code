    public class Claim
    {
    public string Id { get; protected set; }
    public string Type { get; protected set; }
    public string Value { get; protected set; }
    public virtual User User { get; protected set; }
    public int UserId{get;set;}
    public Claim() { }
    }
