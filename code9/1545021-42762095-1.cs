    [IdAttribute("7d7952d1-86df-4e2e-b040-fed335aad775")]
    public class SomeClass
    {
       //example, you'd obviously cache this
       public Guid Id => GetType().GetCustomAttribute<IdAttribute>().Id;
       //...
    }
