    var questions = db.Questions
                         .Where(x => x.CategoriesID == categoryId)
                         .Select(q => new
                         {
                            q,
                            Counters = q.QuestionCounters.Where(x => x.MemberID == User.Identity.GetUserId()),
                            Favorites = q.QuestionFavorites.Where(x => x.MemberId == User.Identity.GetUserId()),
                         });
