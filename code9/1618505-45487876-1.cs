    public static HomeViewModel ToHomeViewModel(this Question q, string memberId)
    {
        return new HomeViewModel()
        {
            QuestionCounters = q.QuestionCounters.Where(x => x.MemberID == memberId),
            QuestionFavorites = q.QuestionFavorites.Where(x => x.MemberId == memberId),
            QuestionTags = q.QuestionTags
        };
    }
