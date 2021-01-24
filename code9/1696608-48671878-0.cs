        public class CourseTn
        {
            // Pk
            public int CourseTnId { get; set; }
            // Properties
            public string Title { get; set; }
            public virtual List<CourseTnImage> CourseImage { get; set; }
            public virtual List<ChapterTn> Chapters { get; set; }
            public AdministratorTnAccount AdministratorTnAccount { get; set; }
            public Guid? AdministratorTnAccountId { get; set; }
            public ClientTnAccount ClientTnAccount { get; set; }
            public Guid? ClientTnAccountId { get; set; }
        }
        public class ChapterTn
        {
            // Pk
            public int ChapterTnId { get; set; }
            // Properties
            public string ChapterName { get; set; }
            public virtual List<ChapterTnImage> ChapterImage { get; set; }
            public virtual List<SectionTn> Sections { get; set; }
            // FK
            public virtual CourseTn CourseTn { get; set; }
            public int CourseTnId { get; set; }
        }
