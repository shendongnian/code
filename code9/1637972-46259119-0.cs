Programmer().GetType().GetProperties().Where(p => p.PropertyType.IsPublic && p.DeclaringType == typeof(Programmer));
        public class Human
        {
            public int Age { get; set; }
        }
        public class Programmer : Human
        {
            public int YearsExperience { get; set; }
            private string FavLanguage { get; set; }
        }
