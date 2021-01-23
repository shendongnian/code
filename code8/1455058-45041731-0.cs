    public class Recaptcha
    {
        public bool ValidateCaptcha(string sitekey, string responseRecaptcha)
        {
            //var response = Request["g-recaptcha-response"];  //part of the parameter << you need to pass this as your responseRecaptcha
            //secret that was generated in key value pair
           //part of the parameter
            var client = new WebClient();
            var reply =
                client.DownloadString(
                    string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}",sitekey,responseRecaptcha));
            var captchaResponse = JsonConvert.DeserializeObject<CaptchaResponse>(reply);
            string status = "";
            //when response is false check for the error message
            if (!captchaResponse.Success)
            {
                if (captchaResponse.ErrorCodes.Count <= 0) return true;
                var error = captchaResponse.ErrorCodes[0].ToLower();
                switch (error)
                {
                    case ("missing-input-secret"):
                        status = "The secret parameter is missing.";
                        return false;
                        break;
                    case ("invalid-input-secret"):
                        status = "The secret parameter is invalid or malformed.";
                        return false;
                        break;
                    case ("missing-input-response"):
                        status = "The response parameter is missing.";
                        return false;
                        break;
                    case ("invalid-input-response"):
                        status = "The response parameter is invalid or malformed.";
                        return false;
                        break;
                    default:
                        status = "Error occured. Please try again";
                        return false;
                        break;
                }
            }
            else
            {
                status = "Valid";
            }
            return true;
        }
    }
    internal class CaptchaResponse
    {
        [JsonProperty("success")]
        public bool Success { get; set; }
        [JsonProperty("error-codes")]
        public List<string> ErrorCodes { get; set; }
    }
