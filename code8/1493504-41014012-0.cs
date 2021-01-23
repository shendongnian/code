    @model SandBox.Web.Models.SiteSettingsAPIModel
    @using (Html.BeginForm("CreateSiteLogo", "SiteSettings", FormMethod.Post, new { enctype = "multipart/form-data" }))
    {
        @Html.TextBoxFor(a => a.SiteNameKey)
    
        <input type="file" name="SiteLogo" id="logo" />
        <input type="submit" />
    }
    public class SiteSettingsAPIModel
    {
        public int Id { get; set; }
        public string SiteNameKey { get; set; }
        public HttpPostedFileBase SiteLogo { get; set; }
        public string ImageFormat { get; set; }
    }
