    Teacher teacher = new Teacher();
    teacher.teacherEducationalQualification = new TeacherEducationalQualification[5];
    // Initialize item at index 0; indices start with 0 so the 1st item has index 0
    teacher.teacherEducationalQualification[0] = new TeacherEducationalQualification();
    teacher.teacherEducationalQualification[0].NameOfDegree= "abc";
    // Initialize item at index 1
    // Initialize item at index 2
    // Initialize item at index 3
    // Initialize item at index 4; this is the last index, your 5th item
    teacher.teacherEducationalQualification[4] = new TeacherEducationalQualification();
    teacher.teacherEducationalQualification[4].NameOfDegree= "xyz";
    // Or in a different way with the help of a local variable
    var qualification;
    qualification = new TeacherEducationalQualification();
    qualification.NameOfDegree= "abc";
    // set other fields
    teacher.teacherEducationalQualification[0] = qualification;
    // ...
    qualification = new TeacherEducationalQualification();
    qualification.NameOfDegree= "xyz";
    // set other fields
    teacher.teacherEducationalQualification[4] = qualification; // last item
