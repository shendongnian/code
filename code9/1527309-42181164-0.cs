    @using(Html.BeginForm("ResolveReview")) {
        @Html.DevExpress().Memo(settings => {
            settings.Name = "txtReviewComment";
        }).GetHtml()
    
        @Html.DevExpress().Button(settings => {
            settings.Name = "btnSaveReview";
            settings.UseSubmitBehavior = true;
        }).GetHtml()
    }
    public ActionResult ResolveReview(bool Pass) {
        EditorExtension.GetValue<string>("txtReviewComment")
    }
