    interface IAdditionalTeacherData
    {
    }
    interface ITeacherToCourse<out T> where T : IAdditionalTeacherData
    {
        int Nr { get; set; }
        T AdditionalTeacherData { get; }
    }
    interface IKurs<out TTeacherToCourse, out TAdditionalTeacherData>
        where TTeacherToCourse : ITeacherToCourse<TAdditionalTeacherData>
        where TAdditionalTeacherData : IAdditionalTeacherData
    {
        int Nr { get; set; }
        IEnumerable<TTeacherToCourse> TeachersToCourses { get; }
    }
