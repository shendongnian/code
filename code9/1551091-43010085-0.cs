       public int CommentCount(int id)
        {
            EducateLesson lesson = context.EducateLessons.Find(id);
            return lesson.Comments.Count;
        }
