    public static class FormatProviderExtension
    {
       public static string ToMomentJSString(this DateTime arg, string format)
       {
           if (arg == null) throw new ArgumentNullException("arg");
           if (arg.GetType() != typeof(DateTime)) return arg.ToString();
           var date = (DateTime)arg;
           format = format
               .Replace("DD", "dd")
               .Replace("YYYY", "yyyy"); //etc.
           return date.ToString(format);
       }
    }
