    [WebMethod]
    public static string GetUniversityCourses(int universityId)
    {
        List<UniversityCourses> courses = ...
        StringBuilder coursesHtml = new StringBuilder();
        foreach(var course in courses) {
            //Generate your html here
            coursesHtml.Append("<div>" + course.Name + "</div>";
        }
        return coursesHtml.toString();
    }
