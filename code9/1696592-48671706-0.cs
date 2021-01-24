    using(Html.BeginForm("viewTasks","ProjectTasks",FormMethod.Post))
         {   
         @foreach (var item in Model)
                {
                    <tr>
                    <td>@Html.DisplayFor(modelItem => item.Description) </td>
                    <td>@Html.DisplayFor(modelItem => item.Teams.Description )</td>
                    <td>@Html.DisplayFor(modelItem => item.PlannedDuration )</td>
                    <td>@item.EarlyStartDate.Value.ToShortDateString()</td>
                    <td>@item.EarlyFinishDate.Value.ToShortDateString()</td>
                    @if (item.ActualStartDate.HasValue)
                        {
                            <td>@item.ActualStartDate.Value.ToShortDateString()</td>
                        }
                        else
                        {
                            <td>@Html.TextBoxFor(modelItem => item.ActualStartDate, 
                                 new { @style = "Width:123px", @type = "date", @Value = "" })</td>
                        }
            
            
                    @if (item.ActualFinishDate.HasValue) 
                        { 
                            <td>@item.ActualFinishDate.Value.ToShortDateString()</td>
                        }
                        else
                        {
                            <td>@Html.TextBoxFor(modelItem => item.ActualFinishDate, 
                                                 new { @style ="width:123px", @type = "date", @Value = "" })</td>
                        }
            
                    @if (item.Completed_By != "")
                    {
                        <td>@Html.DisplayFor(modelItem => item.Users_CompletedBy.LastName), @Html.DisplayFor(modelItem => item.Users_CompletedBy.FirstName)</td>
                    }
                    else if (item.AssignedUser_ID != "")
                    {
                        <td>@Html.DisplayFor(modelItem => item.Users_AssignedUser.LastName ), @Html.DisplayFor(ModelItem => item.Users_AssignedUser.FirstName) </td>
                    }
                    else {
                        <td>None Assigned</td>
                    }
                        <td>
                            @if (!item.ActualFinishDate.HasValue || !item.ActualStartDate.HasValue) 
                            {
                                
                                     <input type="submit" value="Update" />
                                
                            }
                        </td>
                <td>@Html.HiddenFor(modelitem => item.ID)</td>
                </tr>
                        }
        }
