    class XtrAdditionalTeacherData : IAdditionalTeacherData
    {
    }
    class XtrTeacherToCourse : ITeacherToCourse<XtrAdditionalTeacherData>
    {
        public int Nr { get; set; }
        public XtrAdditionalTeacherData AdditionalTeacherData { get; set; }
    }
    class XtrCourse : IKurs<XtrTeacherToCourse, XtrAdditionalTeacherData>
    {
        public int Nr { get; set; }
        public ICollection<XtrTeacherToCourse> TeachersToCourses { get; set; }
        // explicit implementation
        IEnumerable<XtrTeacherToCourse> IKurs<XtrTeacherToCourse, XtrAdditionalTeacherData>.TeachersToCourses => TeachersToCourses;
    }
    class AgsAdditionalTeacherData : IAdditionalTeacherData
    {
    }
    class AgsTeacherToCourse : ITeacherToCourse<AgsAdditionalTeacherData>
    {
        public int Nr { get; set; }
        public AgsAdditionalTeacherData AdditionalTeacherData { get; set; }
    }
    class AgsCourse : IKurs<AgsTeacherToCourse, AgsAdditionalTeacherData>
    {
        public int Nr { get; set; }
        public ICollection<AgsTeacherToCourse> TeachersToCourses { get; set; }
        // explicit implementation
        IEnumerable<AgsTeacherToCourse> IKurs<AgsTeacherToCourse, AgsAdditionalTeacherData>.TeachersToCourses => TeachersToCourses;
    }
