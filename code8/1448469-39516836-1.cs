    namespace MyApp.App_Start
    {
        public class MyAppMapping : Profile
        {
            public MyAppMapping()
            {
            
                CreateMap<Person, Dog>();
                //You can also create a reverse mapping
                CreateMap<Dog, Person>();
                /*You can also map claculated value for your destination. 
                Example: you want to append "d-" before the value that will be
                mapped to Name property of the dog*/
            
                CreateMap<Person, Dog>()
                .ForMember(d => d.Days, 
                 conf => conf.ResolveUsing(AppendDogName)); 
            }
            private static object AppendDogName(Person person)
            {
                return "d-" + person.Name;
            }
        }
    }
