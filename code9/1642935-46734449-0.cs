    public class AccountWithFirstLevelResourcesTransformer : AbstractTransformerCreationTask<Account>
    {
    	public AccountWithFirstLevelResourcesTransformer()
    	{
    		TransformResults = accs => from acc in accs
    								   select new Account
    								   {
                                           ...
    									   Resources = acc.Resources.Select(fullResource => new Resource
                                           {
                                                // Only the properties we want loaded here.
                                                Name = fullResource.Name,
                                                ...
                                           })
                                           ...
    								   };
    	}
    }
