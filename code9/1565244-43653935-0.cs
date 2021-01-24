    public class Customer
    {
      public string FirstName { get; set; }
      public string LastName { get; set; }
    
      private static readonly CompiledExpression<Customer, string> fullNameExpression
         = DefaultTranslationOf<Customer>.Property(e => e.FullName).Is(e => e.FirstName + " " + e.LastName);
    
      [NotMapped]
      public string FullName
      {
        get { return fullNameExpression.Evaluate(this); }
      }
    }
    var customers = ctx.Customers
      .Select(c => new
      {
        FullName = c.FullName
      })
      .WithTranslations();
