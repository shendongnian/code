    public static QuestionGroupDTO ToDTO(this QuestionGroup src)
    {
        var dto = new QuestionGroupDTO
        {
            // ...
            RelationQuestionGroups_Questions = src.RelationQuestionGroups_Questions
                                                  .Select(ToDTO)
                                                  .ToList()
        };
        return dto;
    }
