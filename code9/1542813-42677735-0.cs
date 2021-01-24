    @for (var i = 0; i < Model.Swots.Count(); i++)
    {
        ...
        @for (var j = 0; j < Model.Swots[i].SwotParts.Count(); j++)
        {
            if (Model.Swots[i].SwotParts[j].SwotTypeId == SwotType.InternalHelpful || Model.Swots[i].SwotParts[j].SwotTypeId == SwotType.InternalHarmful)
            {
                @Html.Partial("~/Views/Shared/_SwotPart.cshtml", Model.Swots[i].SwotParts[j])
            }
        }
        ...
