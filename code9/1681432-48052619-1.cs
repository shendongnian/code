    public class RandomStudentCreator
    {
        private readonly Random rnd = new Random();
        private readonly IList<string> cities, names;
        private readonly int minAge, maxAge;
        public RandomStudentCreator(
            IList<string> names,
            IList<string> cities,
            int minimumInckusiveAge,
            int maximumExclusiveAge)
        {
             //Argument validation here
             this.cities = cities;
             this.names = names;
             minAge = minimumInckusiveAge;
             maxAge = maximumExclusiveAge;
        }
        public Student Next()
        {
            var student = new Student();
            student.Name = names[rnd.Next(names.Count);
            student.City = cities[rnd.Next(cities.Count);
            Student.Age = rnd.Next(minAge, maxAge);
        }
    }
