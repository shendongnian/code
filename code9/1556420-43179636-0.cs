     public class PersonHealthInfo
     {
         public Person Person {get; set; }
         public HealthInfo HealthInfo {get; set; }
     }
    ObservableCollection<PersonHealthInfo> persons = new ObservableCollection<PersonHealthInfo>();
    var person1 = new PersonHealthInfo
    {
        Person = new Person { Id = 1, Name = "Name1", Surname = "Surname1" },
        HealthInfo = new HealthInfo { BMI = 1, DietPlan = "Banting", HeartRate = 20 }
    }
    persons.Add(person1);
