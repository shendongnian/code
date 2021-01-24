    using Microsoft.AspNetCore.Mvc;
    using Kendo.Mvc.UI;
    using Kendo.Mvc.Extensions;
    using System.Collections;
    
    namespace dotnet_angular.Controllers
    {
       [Route("api/Products")]
       public class SampleController : Controller
       {
           [HttpGet]
           public JsonResult GetProducts([DataSourceRequest]DataSourceRequest request)
           {
               var result = Json(this.products.ToDataSourceResult(request));
               return result;
           }
    ...
