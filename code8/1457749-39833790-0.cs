        public static class Extenders
        {
            public static string ToString(this string text, ServerType ServerType)
            {
                switch (ServerType)
                {
                    case ServerType.Database:
                        return "Database server";
                    case ServerType.Web:
                        return "Web server";
                }
                // other ones, just use the base method
                return ServerType.ToString();
            }
        }
