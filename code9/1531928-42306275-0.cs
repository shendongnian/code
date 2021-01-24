    @model MyModel
    @{
        Model.IsPersistable = Model.StoreAsIndiv || Model.StoreAsOrg;
    }
    @Html.HiddenFor(x => Model.IsPersistable)
