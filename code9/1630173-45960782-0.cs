    public class Doctor<T> {
        public T Id { get; set; }
        public int Filial { get; set; }   //Suposing Filial is not a foreing key
        public string ShortName { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
    
        public T? DepartmentId { get; set; }
        public Department Department { get; set; }
    }
