    public IEnumerable<COURSES> GetCourseDetails(SearchModel searchModel) 
    {
        // Not sure what your database context is named, but use the correct name here
        using (var db = new DatabaseContext())
        {
            var coursesToReturn = db.Courses.Where(c =>
                 (string.IsNullOrEmpty(searchModel.CourseName) || c.COURSE_NAME.Contains(searchModel.CourseName)) &&
                 (string.IsNullOrEmpty(searchModel.LectureName) || c.LECTURES.Any(l => l.LEC_NAME.Contains(searchModel.LectureName)) &&
                 (string.IsNullOrEmpty(searchModel.LectureTag) || c.LECTURES.Any(l => l.LECTURE_TAGS.Any(lt => lt.TAG_NAME.Equals(searchModel.LectureTag))));
            return coursesToReturn.AsEnumerable();
        }
    }
