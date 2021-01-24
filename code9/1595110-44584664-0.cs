    interface ITeacherToCourse<T> where T : IAdditionalTeacherData
    {
        int Nr { get; set; }
        T AdditionalTeacherData { get; set; }
    }
    class XtrTeacherToCourse : ITeacherToCourse<XtrAdditionalTeacherData>
    {
        public int Nr { get; set; }
        public XtrAdditionalTeacherData AdditionalTeacherData { get; set; }
    }
    class AgsTeacherToCourse : ITeacherToCourse<AgsAdditionalTeacherData>
    {
        public int Nr { get; set; }
        public AgsAdditionalTeacherData AdditionalTeacherData { get; set; }
    }
