    return Json(new { result = "SingUp", Urls = Url.Action("SignUp", "ProjectV3", new { email_add = Base64Encode(email_add)}) })
...
    public static string Base64Encode(string plainText) {
          var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
          return System.Convert.ToBase64String(plainTextBytes);
        }
