    public class Rule
    {
       public Rule()
       {
          Codes = new HashSet<Code>();
       }
       public int RuleId { get; set; }
    
       public ICollection<Code> Codes { get; set; }
    }
    public Code
    {
       public int CodeId { get; set; }
       public int RuleId { get; set; }
       public virtual Rule Rule { get; set; }
    }
