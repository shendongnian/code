    List<grade> grades = new List<grade>(); // instead of List<int>
    // ...
    grades.Add(new grade 
    { 
        studentinfo = Students.Where(s => s.scode == 1).First(),
        courseinfo = courses.Where(c => c.code == 1).First(),
        value = 20.0d,
        term = 1
    });
    // ...
    grades.ForEach((grade) => { Console.WriteLine(grade.studentinfo.name + " " + grade.studentinfo.lastname + " " + grade.courseinfo.name + " " + grade.value); });
