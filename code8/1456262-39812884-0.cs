    @{
        var newRating = new xxxx.ViewModel.RateReviewVM
        {
            ReviewId = Model.Id,
            RatingList = new SelectList(Enumerable.Range(1, 10))
        };
        Html.RenderPartial("_RatingPartial", newRating);
    }
