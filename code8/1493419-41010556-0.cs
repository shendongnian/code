    IQueryable<long> clientsWithoutFeature = from cf1 in db.Features
    join cf2 in db.Features on new { cf1.Client, IsTargetFeature = true }
        equals new { cf2.Client, IsTargetFeature = cf2.Feature = 8 }
    where cf1.Feature != 9
    select cf1.Client;
    IQueryable<long> clientsWithFeature = from cf1 in db.Features
    join cf2 in db.Features on new { cf1.Client, IsTargetFeature = true }
        equals new { cf2.Client, IsTargetFeature = cf2.Feature = 8 }
    where cf1.Feature == 9
    select cf1.Client;
