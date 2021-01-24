    var response = client.Search<Document>(x => x
    	.Query(q => q
    		.FunctionScore(fs => fs
    			.Functions(fu => fu
    				.FieldValueFactor(fvf => fvf
                        .Field(f => f.PriceStatus)
                        .Factor(-1)
                        .Modifier(FieldValueFactorModifier.None)
                    )
    			)
    		)
    	)
    );
    public class Document
    {
        public string Title { get; set; }
    
        public int PriceStatus { get; set; }
    }
