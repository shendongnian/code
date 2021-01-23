    public class Jhon2Transformer : AbstractTransformerCreationTask<Jhon>
    {
	      public Jhon2Transformer ()
	      {
		      TransformResults = jhons => from jhon in jhons
                                          from cat in jhon.Cats
									      select new
										  {
										      Name = jhon.Name,
                                              Cat = cat
										  };
	      }
    }
