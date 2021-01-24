    private List<string> GetErrorMessagesFromList<T>(List<T> aList) where T : IErrorMessage {
        return aList.Where(x => !String.IsNullOrEmpty(x.ErrorMessage)).Select(x => x.ErrorMessage).ToList();
    }
    public List<string> GetErrorMessages() {
        return GetErrorMessagesFromList(CampusList)
                .Concat(GetErrorMessagesFromList(CourseList))
                .Concat(GetErrorMessagesFromList(StudentList))
                .ToList();
    }
