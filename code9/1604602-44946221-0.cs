    public class Foo {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Active {
            get { return StartDate < DateTime.Now && EndDate > DateTime.Now }
        }
    }
    public class FooRepository {
        public IEnumerable<Foo> ActiveFoos { get { return DataContext.Foos.Where(x => x.Active) } }
    }
