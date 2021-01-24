      static class Utility
        {
            internal static string FileUploadRoot
            {
                get
                {
                    return ConfigurationManager.AppSettings["FileUploadRoot"];
                }
            }
        }
