    var newList = list.Select(x => new {
       ColA = x.ColA,
       ColB = x.ColB,
       ColC = x.ColC, 
       CustomColA = x.ColA+10,
       CustomColB = x.ColB+30,
       CustomColC = x.ColC+50,
    });
