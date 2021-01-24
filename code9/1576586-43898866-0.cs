    public class ViewModel
    {
      public Vereniging {get;set;}
      public Saldo {get;set;}
    }
    public IEnumerable<ViewModel> GetVerenigingenperLid(int lidId)
    {
        return  _context.Vereniging    // your starting point - table in the "from" statement
                    .Join(_context.Saldo, // the source table of the inner join
                    a => a.verenigingId,        // Select the primary key (the first part of the "on" clause in an sql "join" statement)
                    b => b.verenigingId,   // Select the foreign key (the second part of the "on" clause)
                    (a, b) => new ViewModel { Vereniging = a, Saldo = b }) // selection
                    .Where(c => c.Saldo.lidId == lidId);
    }
