    public class CourseLesson
    {
        public int Id { get; set; }    
        public string Title { get; set; }    
        public string Content { get; set; }
    
        [InverseProperty("CourseLesson")]
        public ICollection<CourseLessonTestQuestion> CourseLessonTestQuestions { get; set; }
    
        [InverseProperty("ReturnCourseLesson")]
        public ICollection<CourseLessonTestQuestion> ReturnCourseLessons { get; set; }    
    }
