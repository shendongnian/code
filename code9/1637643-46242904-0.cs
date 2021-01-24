        public static class InvocationHelper
        {
           public static string SafeInvoke(Func<string, string> f, string request)
           {
               try
               {
                   return f(request);    
               }
               catch(Exception ex)
               {
                   NofityAboutException(ex);
                   return null;
               }
           }
        }
