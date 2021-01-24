    @inherits Umbraco.Web.Mvc.UmbracoTemplatePage
    @{
        string folderPath = Server.MapPath("/media");
        string[] files = Directory.GetFiles(folderPath + "/" + Model.Content.GetPropertyValue("placeID"));
    }
    @foreach (string item in files){
        <img src="/media/@Model.Content.GetPropertyValue("placeID")/@Path.GetFileName(item)" />
    } 
