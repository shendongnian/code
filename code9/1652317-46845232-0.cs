    var info=DbSet<Cars>().ToList();
    foreach(a in info){
    Console.Writeline(a.Brand);
    Console.Writeline(a.Model);
    Console.Writeline(a);
