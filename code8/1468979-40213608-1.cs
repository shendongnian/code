        public class DescriptiveMeaningOfAClass
        {
             public string Value { get; set; }
         }
        public class MyClass : IMyInterface
        {
             private string _field;
             readonly IRepository _repo;
             public MyClass(DescriptiveMeaningOfAClass something, IRepository repo)
             {
                 _field = something.Value;
                 _repo = repo;
             }
         }
