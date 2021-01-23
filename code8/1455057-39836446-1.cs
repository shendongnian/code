    public partial class page : System.Web.UI.Page
    {
        private string CAPTCHA_SECRET_KEY = @"6LeIxAcTAAAAAGG-vFI1TnRWxMZNFuojJ4WifJWe"; // WARNING: FAKE SECRET KEY
        protected void Page_Load(object sender, EventArgs e)
        {
            if(IsPostBack)
            {
                String username = unameInput.Text;
                String password = pwordInput.Text;
    
                if (validate())
                {
                    // ...
                }
            }
        }
        
        // Thanks to http://www.thatsoftwaredude.com/content/6235/implementing-googles-no-captcha-recaptcha-in-aspnet
        private bool validate()
        {
            string url = @"https://www.google.com/recaptcha/api/siteverify";
            WebRequest request = WebRequest.Create(url);
            string postData = string.Format("secret={0}&response={1}&remoteip={2}", CAPTCHA_SECRET_KEY, Request["g-recaptcha-response"], Request.UserHostAddress);
            
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = postData.Length;
            
            StreamWriter writer = new StreamWriter(request.GetRequestStream());
            writer.Write(postData);
            writer.Close();
            
            StreamReader reader = new StreamReader(request.GetResponse().GetResponseStream());
            string responseData = reader.ReadToEnd();
            
            JavaScriptSerializer jss = new JavaScriptSerializer();
            CaptchaResponse cResponse = jss.Deserialize<CaptchaResponse>(responseData);
            return cResponse.success;
        }
        catch(WebException)
        {
            return true; // TODO: Change to false when releasing
        }
    }
    class CaptchaResponse
    {
        public bool success { get; set; }
    }
