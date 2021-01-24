    var results = context.Table1
        .Where( a => a.b.Col1.Equals("ABC")
        .Select( x => new SampleDto {
            OutletCd = a.id,
            //other cols
        })
        .ToList();
    foreach( var sampleDto in results ) {
        sampleDto.Table2 = context.Table2.Where( x => x.Condition ).ToList();
    }
