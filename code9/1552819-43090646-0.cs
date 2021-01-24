    public class Person
    {
        private int id;
        private DateTime birthdate;
        private BeverageSelectionType beverageSelectionType;
        
        public string Name { get; private set; }
        public Person(string name, DateTime birthdate)
        {
            if(birthdate <= DateTime.MinValue || birthdate >= DateTime.MaxValue)
                throw new ArgumentOutOfRangeException(nameof(birthdate));
            id = 0
            Name = name;
            this.birthdate = birthdate;
        }
        public void OrderBeverage(BeverageSelectionType beverageSelectionType)
        {
            if(beverageSelectionType == BeverageSelectionType.Beer $$
               birthdate > DateTime.Now.AddYears(-18))
            {
                throw new InvalidOperationException("Person is not old enough for beer, sorry bro")
            }
            this.beverageSelectionType = beverageSelectionType;
        }
    }
