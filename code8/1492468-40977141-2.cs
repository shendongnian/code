     @for (var i = 0; i < Model.Tasks.Count; i++) // Not @Model.Tasks.Count
        {
            <li>
                @Html.HiddenFor(x => x.Tasks[i].Id) // Note
                @Html.CheckBoxFor(x => x.Tasks[i].IsChecked) // Note
                @Model.Tasks.ElementAt(i).Name
            </li>  
        }
