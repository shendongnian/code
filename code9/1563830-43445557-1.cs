    public DateTime When 
    { 
      get 
      {
        // The next 2 variables should really be static to the class.
        var culture = CultureInfo.CreateSpecificCulture("en-US");
        var format = "MMMM yyyy";
        return DateTime.ParseExact(this.Title, format, culture);
      }
    }
    @foreach (var item in (Model.OrderBy(x => x.When)))
    {
        <li><a href="@Url.Action("Index", "BudgetHistories", 
           new { Title = item.Title })">
           <i class="fa fa-dollar"></i> 
           <span>@item.Title</span></a>
        </li>
    }
