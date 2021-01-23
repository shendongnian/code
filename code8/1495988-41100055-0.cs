    <div class="panel-body">
            @{
                @:<dl class="dl-horizontal">
                if (Model.Guests != null)
                {
                    for (int i = 0; i < Model.Guests.Count; i++)
                    {
                        @:<dt>@Html.DisplayNameFor(m => m.Guests[i].GuestName)</dt>
                        @:<dt>@Html.EditorFor(m => m.Guests[i].GuestName)</dt>
                        @Html.HiddenFor(m => m.Guests[i].EventID)
                        @Html.HiddenFor(m => m.Guests[i].ID)
                    }
                }
                 @:</dl>
            }
        </div>
