    public partial class Entities : DbContext
        {
            public Entities()
                : base(new OracleConnection("DATA SOURCE=Server; PASSWORD=123;USER ID=SYSTEM"), true)
            {
    
            }
          }
