    <div class="paging">
    @if (Model.Pages > 10)
    {
            @for (int i = 1; i < 5; i++)
            {
              string Url = String.Format("/View/Thread/{0}?page={1}", Model.Thread.Id, i);
              <a href="@Url">@i</a>
            }
            ...
            @for (int i = Model.Pages - 5; i < Model.Pages; i++)
            {
              string Url = String.Format("/View/Thread/{0}?page={1}", Model.Thread.Id, i);
              <a href="@Url">@i</a>
            }
    }
    else
    {
            @for (int i = 1; i < Model.Pages; i++)
            {
              string Url = String.Format("/View/Thread/{0}?page={1}", Model.Thread.Id, i);
              <a href="@Url">@i</a>
            }
    }
    </div>
