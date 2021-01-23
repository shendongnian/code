    public class CustomNameValueCollection:NameValueCollection
    {
         public override String ToString()
         {
             return string.Join("&", a.AllKeys.Select(k => $"{k}={a[k]}"));
         }
    }
