    @switch (Model.DataType)
    {
        case ConfigDataType.String:
            {
                var value = Model.Value == null ? "" : Model.Value;
                @Html.EditorFor(m => value, "string", Model.PostId)
                loadScript("~/Content/js/register.js", function(){
                //initialization code
                });
                break;
            }
        case ConfigDataType.Bool:
            {
                @Html.EditorFor(m => Model.Value, "", Model.PostId)
                loadScript("~/Content/js/register.js", function(){
                //initialization code
                });
                break;
            }
        case ConfigDataType.Image:
            {
                @Html.ConfigImage(Model.Key, m => Model.Value, Url.Action(ApplicationController.ActionUploadImage), Model.PostId)
                loadScript("~/Content/js/register.js", function(){
                //initialization code
                });
                break;
            }
    }
