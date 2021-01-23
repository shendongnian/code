    @for (int i = 0; i < Model.ImpactAreas.Count; i++)
    {
        @Html.HiddenFor(m => m.ImpactAreas[i].ImpactAreaID)
        @Html.CheckBoxFor(m => m.ImpactAreas[i].Checked)
        // assumes you want the Name value to be used as the label for the checkbox
        @Html.LabelFor(m => m.ImpactAreas[i].Checked, Model.ImpactAreas[i].Name)
    }
