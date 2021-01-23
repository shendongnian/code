    public class CustomNameValueCollection:NameValueCollection
    {
         public override String ToString()
         {
             return string.Join("&", AllKeys.Select(k => $"{k}={this[k]}"));
         }
    }
