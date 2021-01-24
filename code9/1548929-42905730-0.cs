    var result=persons.ToDictionary(p=>p.id,
                                    p=>new{
                                           Person=p,
                                           MaxDate=new DateTime(
                                                  Math.Max(p.Activity1.Ticks,
                                                  Math.Max(p.Activity2.Ticks,p2.Activity3.Ticks)))});
