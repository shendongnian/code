    <div class="paging">
    @if (Model.Pages > 11 && ViewBag.currentPage > 6)
    {
            @for (int i = ViewBag.currentPage - 6; i < ViewBag.currentPage -1; i++)
            {
              string Url = String.Format("/View/Thread/{0}?page={1}", Model.Thread.Id, i);
              <a href="@Url">@i</a>
            }
            ...
            @for (int i = ViewBag.currentPage + 1; i < ViewBag.currentPage + 6; i++)
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
