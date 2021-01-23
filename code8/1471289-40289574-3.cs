    public void UpdateDiary(Diary Diary)
    {
        _context.Update(Diary);
        _context.SaveChanges();
    }
