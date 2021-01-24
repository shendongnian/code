    public int GetGrade(string studentName, string course) {
        if (studentsByName.ContainsKey(studentName)) {
            var student = studentsByName[studentName];
            var courseInfo = student.Infos.FirstOrDefault(i => i.Course == course);
            if (courseInfo != null) {
                return courseInfo.Grade;
            }
            else {
                throw new ArgumentExpection($"Student '{studentName}' did not take the course '{course}'.", nameof(course));
            }
        }
        else {
            throw new ArgumentExpection($"No student '{studentName}' found.", nameof(studentName));
        }
    }
