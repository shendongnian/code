    @using System.Web.Mvc.Html
    @helper RadioButtonList(WebViewPage page, string groupName, IEnumerable<System.Web.Mvc.SelectListItem> items)
    {
        <div>
        @foreach (var item in items)
        {            
             @page.Html.RadioButton(@groupName, @item.Value, false)  <br />            
        }
        </div>
    }
