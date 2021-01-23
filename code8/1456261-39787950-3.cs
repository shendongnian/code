    @model WebApp.Models.Review
    @{
    ViewBag.Title = "Details";
    }
    @{
        var newRating = new WebApp.Models.RateReview { ReviewId = Model.Id };
        Html.RenderPartial("_RatingPartial", newRating);
    }
    <h2>Details</h2>
    <div>
    <h4>Review</h4>
    <hr />
    ...
