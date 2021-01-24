    public class PersonViewModel
    {
        public PersonViewModel(Person person)
        {
            Name = person.Name;
            CityName = person.CityName;
            JobName = person.JobName;
        }
        public string Name { get; set; }
        public string CityName { get; set; }
        public string JobName { get; set; }
        public int? CityPopulation { get; set; }
        public int? AverageSalary { get; set; }
    }
