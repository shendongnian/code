    <div class="panel panel-default">
        <div class="panel-heading">
            <h3 class="panel-title">@Resources.StatusMessage</h3>
        </div>
        @{
          if(Model.StatusMessages != null)
          {
            for (int i = 0; i < Model.StatusMessages.Count; i++)
            {
            @Html.DisplayFor(m => m.StatusMessages[i])
            }
          }
          else
          {
           @Html.Display("No Status")
          }
         }
        <div class="panel-footer">
            @Html.ActionLink(Resources.AddStatusMessage, "AddStatusMessage", new {Id = Model.Id})
        </div>
    </div>
