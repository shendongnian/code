    public class MyDocument
    {
        public long Clicks { get; set; } 
    }
	var response = client.Search<MyDocument>(s => s
		.Query(q => q
			.FunctionScore(fs => fs
				.Query(fq => fq
                    // your search query here
					.MatchAll()
				)
				.Functions(fun => fun
                    // boost by a factor of the square root of the click value 
                    // for documents with clicks greater than 0
					.FieldValueFactor(fvf => fvf
						.Field(f => f.Clicks)
						.Filter(fi => fi
							.Range(r => r
								.Field(rf => rf.Clicks)
								.GreaterThan(0)
							)
						)
						.Factor(1.5)
						.Modifier(FieldValueFactorModifier.SquareRoot)
					)
				)
				.ScoreMode(FunctionScoreMode.Multiply)
			)
		)
	);
