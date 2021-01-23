    public IList<Lesson> GetLessonWhereGrpId(int grpId)
    {
        return _LessonRepository.GetList(
            d => d.Group.Select(x => x.Id).Contains(grpId)
            );
    }
