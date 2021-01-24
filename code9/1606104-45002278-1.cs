    public IEnumerable<QuestionCategory> QuestionCategoryList = new List<QuestionCategory> { 
        new QuestionCategory {
            Id = 1,
            QuestionCat = "Red"
        },
        new QuestionCategory {
            Id = 2,
            QuestionCat = "Blue"
        }
    };
    
    @Html.DropDownListFor(q => q.Question.QuestionCategoryId, new SelectList(QuestionCategoryList, "Id", "QuestionCat"), "Select Question Category", new { @class = "form-control" })
