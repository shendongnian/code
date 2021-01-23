    var grouped = Students_var.GroupBy(x => x.ID).Select(x => new Student
            {
                ID = x.Key,
                Exam = x.SelectMany(z=> z.Exam).ToList()
            }).ToList();
    public class Student
    {
        public int ID { get; set; }
        public List<in>t Exam { get; set; }
    }
