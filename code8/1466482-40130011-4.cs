    public IList<Lesson> GetLessonWhereGrpId(int grpId) 
    { 
        GroupBLL grpbll = new GroupBLL(); 
        grp = grpbll.GetGroupById(grpId, g => g.lesson); 
    
        return grp.lesson.ToList(); 
    }
