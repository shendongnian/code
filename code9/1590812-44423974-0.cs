    @var flag = HelperToTables.ContentText.ContentIdValue.GetInfoContentInfo.GetColBool(Model.HiddenId);
    @if (flag)
    {
        @Html.Raw("col-md-8");
    }
    else
    {
        @Html.Raw("col-md-12");
    }
