    public class John2Transformer : AbstractTransformerCreationTask<John>
    {
	      public John2Transformer ()
	      {
		      TransformResults = johns => from john in johns
                                          from cat in john.Cats
									      select new
										  {
										      Name = john.Name,
                                              Cat = cat
										  };
	      }
    }
