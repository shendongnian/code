    using System.ComponentModel;
    using Microsoft.VisualStudio.TestTools.WebTesting;
     
    namespace WebTests.RequestPlugins
    {
        [DisplayName("Add JSON content to Body")]
        [Description("HEY! Tip! Uglify your JSON before pasting.")]
        public class AddJsonContentToBody : WebTestRequestPlugin
        {
            [Description("Assigns the HTTP Body payload to the content provided and sets the content type to application/json")]
            public string JsonContent { get; set; }
     
        public override void PreRequest(object sender, PreRequestEventArgs e)
        {
            var stringBody = new StringHttpBody();
            stringBody.BodyString = JsonContent;
            stringBody.ContentType = "application/json";
 
            e.Request.Body = stringBody;
        }
    }
