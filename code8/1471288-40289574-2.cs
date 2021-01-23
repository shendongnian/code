    public Diary SearchDiary(int DiaryId)
    {
        return _context.Diaries
            .Include(p => p.Entries)
            .Include(p => p.Tags)
            .FirstOrDefault(p => p.IdDiary == DiaryId);
    }
