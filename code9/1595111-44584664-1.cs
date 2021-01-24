    interface ITeacherToCourse<out T> where T : IAdditionalTeacherData
    {
        int Nr { get; set; }
        T AdditionalTeacherData { get; }
    }
