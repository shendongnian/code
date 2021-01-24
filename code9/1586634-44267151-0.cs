    @{
        var converted = JsonConvert.DeserializeObject(Model.JsonData);
        if (converted is JObject)
        {
            isMultiLevel = true;
        }
        else if (converted is JArray)
        {
            isSingleLevel = true;
        }
    }
    @if (isMultiLevel)
    {
        Html.RenderPartial("Details_MultiLevelResult", Model);
    }
    else if (isSingleLevel) //might not be multiLevel nor singleLevel (if no data)
    {
        Html.RenderPartial("Details_SingleLevelResult", Model);
    }
