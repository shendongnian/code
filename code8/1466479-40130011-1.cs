    public IList<Lesson> GetLessonWhereGrpId(int grpId)
    {
        return _LessonRepository.GetList(
            d => d.Group.Any(x => x.Id == grpId)
            );
    }
