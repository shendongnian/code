    class Program
    {
        static void Main(string[] args)
        {
            DataTable dt = new DataTable("table");
            dt.Columns.AddRange(new[]
            {
                new DataColumn("StudentName", typeof(string)),
                new DataColumn("StudentCourse", typeof(string)),
                new DataColumn("StudentId", typeof(int)),
                new DataColumn("MotherName", typeof(string)),
                new DataColumn("FatherName", typeof(string))
            });
            dt.PrimaryKey = new[] { dt.Columns["StudentId"] };
            // Father not specified
            dt.Rows.Add("Johnny Doe, Jr.", "OfCourse", 1, "Jane Doe", DBNull.Value);
            var dr = dt.Rows.Find(1);
            var studentlist = new List<StudentViewModel>();
            // Same as you did
            studentlist.Add(
                new StudentViewModel
                {
                    StudentName = Convert.ToString(dr["StudentName"]),
                    StudentCourse = Convert.ToString(dr["StudentCourse"]),
                    StudentId = Convert.ToInt32(dr["StudentId"]),
                    MotherName = Convert.ToString(dr["MotherName"]),
                    FatherName = Convert.ToString(dr["FatherName"])
                });
            foreach (var student in studentlist)
            {
                Console.WriteLine(student);
            }
            Console.WriteLine("Done");
            Console.Read();
        }
        class StudentViewModel
        {
            public string StudentName { get; set; }
            public string StudentCourse { get; set; }
            public int StudentId { get; set; }
            public string MotherName { get; set; }
            public string FatherName { get; set; }
            public override string ToString()
            {
                return $"[{StudentId}] {StudentName} (Mother: {MotherName}; Father: {FatherName}) attending: {StudentCourse}";
            }
        }
    }
