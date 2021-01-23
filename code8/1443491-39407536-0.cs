    @using System.Web.Mvc.Html
    @using WebApplication2.Models
    @model WebApplication2.Models.MyClass
    @{
        ViewBag.Title = "Index";
    }
    @Html.EnumDropDownListFor(model => model.occupancyTimeline)
