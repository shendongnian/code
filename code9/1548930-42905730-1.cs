    var result=persons.ToDictionary(p=>p.id,
                                    p=>new{
                                           Person=p,
                                           MaxDate=new[]{p.Activity1,
                                                         p.Activity2,
                                                         p.Activity3}.Max()});
