    var university = new University();
    university.UniversityId = newUniId;
    university.UniversityName = UniversityComboBox1.Text;
    
    // these lines are sufficient to build the relationships between entities, you don't have to set both sides
    university.UniversityFaculties.Add(faculty);
    university.UniversityDepartments.Add(department);
    university.Students.Add(student);
    student.Universities.Add(university);
    // use foreign key properties to build the relationship without having large graphs when adding to context
    faculty.UniversityId = newUniId;
    department.UniversityId = newUniId;
    
    faculty.Students.Add(student);
    department.Students.Add(student);
