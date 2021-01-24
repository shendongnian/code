    @using WebApplication1.Models
    @using System.Reflection
    @using WebApplication1.Extensions
    
    @model Tuple<Thing, PropertyInfo>
    
    @Html.DisplayFor("Item1."+Model.Item2.Name)
