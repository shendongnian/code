    public class PostXmlModel {
        [AllowHtml]
        public string Xml {get; set;}
    }
    [HttpPost]
    public ActionResult MyAction(PostXmlModel postData) {
        string xml = postData.Xml;
        // ...
    }
