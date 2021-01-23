    var subjectMarksByStudent = new Dictionary<string, Dictionary<string, int>>();
    foreach (var studentMark in studentMarks)
    {
        Dictionary<string, int> subjectsAndMarksForStudent;
        if (subjectMarksByStudent.TryGetValue(studentMark.Name, out subjectsAndMarksForStudent))
        {
            subjectsAndMarksForStudent.Add(studentMark.Subject, studentMark.Mark);
        }
        else
        {
            subjectMarksByStudent.Add(studentMark.Name, new Dictionary<string, int> {{ studentMark.Subject, studentMark.Mark }});
        }
    } 
