    var MaleStudents = students.Where(Std => Std.Gender.ToUpper() == "M");
    var FemaleStudents = students.Where(Std => Std.Gender.ToUpper() == "F");
    
    //List for storing top students records           
    List<StudentEntity> TopStudents = new List<StudentEntity>();
    //Adding records to List
    var maxMarksM = MaleStudents.Max(o => o.Marks);
    TopStudents = MaleStudents.Where(o => o.Marks == maxMarksM).ToList();
    var maxMarksF = FemaleStudents.Max(o => o.Marks);
    TopStudents.AddRange(FemaleStudents.Where(o => o.Marks == maxMarksF).ToList());
    return TopStudents;
