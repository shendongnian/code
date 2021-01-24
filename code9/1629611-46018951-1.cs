    public class PersonFactory
    {
        private readonly IReferenceDataProvider _dataProvider;
       public PersonFactory(IReferenceDataProvider dataProvider)
       {
           _dataProvider = dataProvider;
       }
       public Person Create(string name, string surname, int statusId)
       {
           return new Person
           {
               Name = name,
               Surname = surname,
               StatusId = statusId,
               Statuses = _dataProvider.GetData(DataType.ClientStatus)
           };
       }
    }
