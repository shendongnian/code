    Expression<Action<AssetController>> action = x => x.Create();
    if (Model.Id != -1)
    {
        action = x => x.Edit(Model.Id);
    }
    using (Html.BeginForm(action, ...)
