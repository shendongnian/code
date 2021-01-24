    class Course
    {
        public int Id {get; set;}
        // every Course has zero or more Chapters:
        public virtual ICollection<Chapter> Chapters {get; set;}
        // other properties:
        public CourseLevel Level {get; set;}
        ...
    }
    class Chapter
    {
        public int Id {get; set;}
        // every Chapter belongs to exactly one Course using foreign key
        public int CourseId {get; set;}
        public virtual Course Course {get; set;}
        ... // other properties
    }
