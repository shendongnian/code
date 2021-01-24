    @model SummaryConfigurationVM
    ....
    @using (Html.BeginForm("Summary", "yourControllerName", FormMethod.Get))
    {
        @Html.LabelFor(m => m.Quarter)
        @Html.DropDownListFor(m => m.Quarter, Model.QuarterList, "--Select Quarter--")
        @Html.ValidationMessageFor(m => m.Quarter)
        .... // ditto for Year
        <input type="submit" value="Submit" />
    }
    <table>
        <thead>
            <tr>
                <th>@Html.DisplayNameFor(m => m.Configurations.FirstOrDefault().LineID)</th>
                ....
            </tr>
        </thead>
        <tbody>
            @foreach( var item in Model.Configurations)
            {
                <tr>
                    <td>@Html.DisplayFor(modelItem => item.LineID)</td>
                    .... // other properties of SummaryConfiguration
                </tr>
            }
        </tbody>
    </table>
