    public class Student:Repository<Tbl_Student>
        {
            DataContext context;
            public Student(DataContext context):base(context)
            {
                this.context = context;
            }
        }
