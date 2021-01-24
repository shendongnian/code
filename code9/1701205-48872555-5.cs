    var result = context.Table1.Include( a => a.b )
        .Where( a => a.b.Col1.Equals("ABC")
        .Select( x => new SampleDto {
            OutletCd = a.id,
            //other cols
            Table2 = new SampleDetails {
                Col1 = b.Col1,
                Col2 = b.Col2
            }
        });
