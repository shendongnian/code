    public static Course GetCourse(int id){
     using (DBContext context = new DBContext())
                {
                    return context.Courses.Find(id);
                }
    }
