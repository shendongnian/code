     StringBuilder CourseBuilder = new StringBuilder();
    while (m.Success)
       {
           CourseBuilder.AppendLine(m.ToString());
           m = m.NextMatch();            
       }
    }
    string Course = CourseBuilder.ToString();
