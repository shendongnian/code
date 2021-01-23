    public static bool IsDebugMode(this HtmlHelper htmlHelper)
    {
       #if DEBUG
           return true;
       #else
          return false;
       #endif
    }
